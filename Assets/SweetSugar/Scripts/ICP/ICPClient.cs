using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Agents;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;
using UnityEngine;
using GemEncryption;

namespace LoyaltyCandy {
    public class ICPClient : MonoBehaviour {
        // ========== Events ==========
        public delegate void ResultHandler(bool success, object? result, string? message);
        public event ResultHandler OnRead;
        public event ResultHandler OnSet;
        public event ResultHandler OnRankingReceived;
        public event ResultHandler OnRankUpdated;

        public delegate void ICPClientReady();
        public event ICPClientReady OnICPClientReady;

        // ========== Configuration & State ==========
        public ICPCanisterConfig Config => configuration;
        [SerializeField] private ICPCanisterConfig configuration;

        internal ClimateWalletApiClient climateClient;
        private Coroutine networkMonitorCoroutine;
        private int gameBalance;
        private bool isChecking;
        private bool appliedOfflineGem = false;

        // ========== Initialization ==========
        internal void Connect(IAgent agent) {
            climateClient = new ClimateWalletApiClient(agent, Config.CanisterPrincipal);
            CheckPlayerData();
            OnICPClientReady?.Invoke();

            if (networkMonitorCoroutine != null) StopCoroutine(networkMonitorCoroutine);
            networkMonitorCoroutine = StartCoroutine(MonitorNetworkStatus());
        }

        private IEnumerator MonitorNetworkStatus(float timeoutSeconds = 5f) {
            Debug.Log("Testing canister...");
            Task pingTask = climateClient.Ping();
            float startTime = Time.time;

            while (!pingTask.IsCompleted) {
                if (Time.time - startTime > timeoutSeconds) {
                    Debug.LogWarning("Timeout: Canister didn't respond in time.");
                    yield break;
                }
                yield return null;
            }

            if (pingTask.IsFaulted || pingTask.Exception != null) {
                Debug.LogWarning("Canister is OFFLINE");
                Debug.LogWarning("Reason: " + pingTask.Exception?.Message);
                HandleOfflineMode();
            } else {
                Debug.Log("Canister is ONLINE");
                ApplyOfflineGem();
                yield return new WaitUntil(() => !isChecking);

                var getScoreTask = GetOnlineScoreSafe();
                while (!getScoreTask.IsCompleted) yield return null;

                gameBalance = getScoreTask.Result;
                SetLastKnownBalance(gameBalance);

                if (!appliedOfflineGem) {
                    CheckCoinBalance(gameBalance);
                }

                appliedOfflineGem = false;
            }
            Debug.Log("Testing Completed");
        }

        private async Task<int> GetOnlineScoreSafe() {
            try {
                var data = await climateClient.GetGameData();
                return (int)data.Score;
            } catch (Exception e) {
                Debug.LogError($"Error while fetching score: {e.Message}");
                return gameBalance;
            }
        }

        // ========== Offline Handling ==========
        private void HandleOfflineMode() {
            int currentGems = PlayerPrefs.GetInt("Gems", 0);
            int lastKnownOnlineGem = GetLastKnownGemBalance();
            int offlineGem = currentGems - lastKnownOnlineGem;
            Encryptor.SaveCoins(offlineGem);
        }

        private void ApplyOfflineGem() {
            int offlineGems = Encryptor.LoadCoins<int>();
            if (offlineGems != 0) {
                int lastKnownGem = PlayerPrefs.GetInt("LastKnownOnlineGemBalance", 0);
                int newGemBalance = offlineGems + lastKnownGem;
                SaveCoins(newGemBalance);
                Encryptor.SaveCoins(0);
                appliedOfflineGem = true;
            }
        }

        private int GetLastKnownGemBalance() {
            return PlayerPrefs.GetInt("LastKnownOnlineGemBalance", gameBalance);
        }

        private void SetLastKnownBalance(int balance) {
            PlayerPrefs.SetInt("LastKnownOnlineGemBalance", balance);
            PlayerPrefs.Save();
        }

        // ========== Score Read & Write ==========
        public void ReadScore() {
            StartCoroutine(GetPlayerScoreCoroutine());
        }

        public void SaveCoins(int coins) {
            gameBalance = coins;
            StartCoroutine(UpdatingPlayerScoreCoroutine(coins));
        }

        private async Task<uint> GetPlayerScoreAsync() {
            return await climateClient.ReadScore();
        }

        public IEnumerator GetPlayerScoreCoroutine() {
            Debug.Log("Retrieving Game Data...");
            Task<uint> fetchScoreTask = GetPlayerScoreAsync();
            while (!fetchScoreTask.IsCompleted) yield return null;

            GameDataShared gameData = new GameDataShared();
            if (fetchScoreTask.IsCompletedSuccessfully) {
                gameData.Score = fetchScoreTask.Result;
                Debug.Log($"Game score retrieved: Score: {gameData.Score}");
            }

            OnRead?.Invoke(true, gameData, fetchScoreTask.Exception?.Message);
        }

        // ========== Player Initialization ==========
        public void CheckPlayerData() {
            StartCoroutine(GetOrRegisterGameDataCoroutine());
            StartCoroutine(WeeklyReward());
        }

        public IEnumerator GetOrRegisterGameDataCoroutine(string playerName = "Player", bool isAvatarMale = true) {
            Task<GameDataShared> fetchTask = GetGameDataAsync();
            while (!fetchTask.IsCompleted) yield return null;

            GameDataShared gameData = new GameDataShared();
            string exception = "";

            if (fetchTask.IsCompletedSuccessfully && fetchTask.Result != null) {
                gameData = fetchTask.Result;
            } else {
                Task<GameDataShared> registerTask = RegisteringPlayerAsync(playerName, isAvatarMale);
                while (!registerTask.IsCompleted) yield return null;

                if (registerTask.IsCompletedSuccessfully && registerTask.Result != null) {
                    gameData = registerTask.Result;
                } else {
                    exception = registerTask.Exception?.Message;
                }
            }

            OnRead?.Invoke(true, gameData, exception);
        }

        private async Task<GameDataShared> GetGameDataAsync() {
            return await climateClient.GetGameData();
        }

        private async Task<GameDataShared> RegisteringPlayerAsync(string name, bool isAvatarMale) {
            return await climateClient.RegisterPlayer(name, isAvatarMale);
        }

        // ========== Weekly Reward Check ==========
        private IEnumerator WeeklyReward() {
            Debug.Log("Checking for weekly reward...");
            var task = WeeklyRewardCheckAsync();
            while (!task.IsCompleted) yield return null;
            Debug.Log("WeeklyReward coroutine finished.");
        }

        private async Task WeeklyRewardCheckAsync() {
            try {
                await climateClient.CheckAndMaybeDistributeReward();
                Console.WriteLine("Weekly reward check completed.");
            } catch (Exception ex) {
                Console.WriteLine($" Failed to check/distribute weekly reward: {ex.Message}");
            }
        }

        // ========== Updating Player Score ==========
        public IEnumerator UpdatingPlayerScoreCoroutine(int score) {
            Task updatingScore = updatePlayerScoreAsync(score);
            while (!updatingScore.IsCompleted) yield return null;

            OnSet?.Invoke(
                updatingScore.IsCompletedSuccessfully,
                updatingScore.IsCompletedSuccessfully ? updatingScore : null,
                !updatingScore.IsCompletedSuccessfully ? updatingScore.Exception.Message : null);
        }

        private async Task updatePlayerScoreAsync(int score) {
            await climateClient.UpdatePlayerScore((uint)score);
        }

        // ========== Coin Balance Check ==========
        internal void CheckCoinBalance(int numCoins) {
            if (!isChecking) {
                gameBalance = numCoins;
                isChecking = true;
                OnRead += CompareBalance;
                ReadScore();
            }
        }

        private void CompareBalance(bool success, object result, string message) {
            OnRead -= CompareBalance;

            if (success) {
                GameDataShared gameShareData = (GameDataShared)result;
                int gemValue = (int)gameShareData.Score;
                int icpGem = Mathf.Sign(gemValue) > 0 ? gemValue : gameBalance;
                int diff = icpGem - gameBalance;
                SetLastKnownBalance(diff);
            } else {
                Debug.LogError("Error getting balance: " + message);
            }
            isChecking = false;
        }

        // ========== Ranking ==========
        internal void GetCurrentRank() {
            StartCoroutine(ExecuteCurrentRankRead());
        }

        private IEnumerator ExecuteCurrentRankRead() {
            Task<PRank> task = climateClient.GetCurrentGlobalRanking();
            while (!task.IsCompleted) yield return new WaitForEndOfFrame();
            OnRankUpdated?.Invoke(true, task.Result, null);
        }

        internal void GetRanking(int before, int after, short rank) {
            StartCoroutine(ExecuteRankingRead((uint)before, (uint)after, rank));
        }

        private IEnumerator ExecuteRankingRead(uint before, uint after, short rank) {
            Task<ClimateWallet.Models.RankingResult> task = climateClient.GetGlobalRanking(before, after, rank);
            while (!task.IsCompleted) yield return new WaitForEndOfFrame();

            List<RankingResult> result = new List<RankingResult>();
            foreach (PRank pRank in task.Result.Ranking) {
                result.Add(new RankingResult(pRank.Name, pRank.Rank, (int)pRank.Score));
            }

            OnRankingReceived?.Invoke(true, result, null);
        }
    }
}