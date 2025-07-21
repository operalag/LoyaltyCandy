using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Agents;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;
using UnityEngine;
using GemEncryption;
using UnityEngine.UI;

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
        [SerializeField] private WeeklyRankingRewardManager weeklyRankingRewardManager;


        // ========== Initialization ==========
        internal void Connect(IAgent agent)
        {
            climateClient = new ClimateWalletApiClient(agent, Config.CanisterPrincipal);
            CheckPlayerData();
            OnICPClientReady?.Invoke();

            if (networkMonitorCoroutine != null) StopCoroutine(networkMonitorCoroutine);
            networkMonitorCoroutine = StartCoroutine(MonitorNetworkStatus());
        }

        private IEnumerator MonitorNetworkStatus(float timeoutSeconds = 5f) {
            // Debug.Log("Testing canister...");
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

                // var getScoreTask = GetOnlineScoreSafe();
                // while (!getScoreTask.IsCompleted) yield return null;

                StartCoroutine(GetPlayerScoreCoroutine((score) => {
                    gameBalance = (int)score;
                    Debug.Log("Score received in callback: " + score);
                    // Do something with score
                }));
            
                // gameBalance = getScoreTask.Result;
                SetLastKnownBalance(gameBalance);

                if (!appliedOfflineGem) {
                    CheckCoinBalance(gameBalance);
                }

                appliedOfflineGem = false;
            }
            Debug.Log("Testing Completed");
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

        public void SaveCoins(int coins) {
            gameBalance = coins;
            StartCoroutine(UpdatingPlayerScoreCoroutine(coins));
        }

        private async Task<uint> GetPlayerScoreAsync() {
            return await climateClient.ReadScore();
        }

        private async Task RewardHasClaimedAsync() {
            await climateClient.RewardClaimed(false);;
        }

        private void ClaimReward() // on Claim reward
        {
            StartCoroutine(RewardHasClaimedCoroutine());
        }

        public IEnumerator RewardHasClaimedCoroutine()
        {
            Debug.Log("Retrieving Game Data...");
            Task rewardClaimTask = RewardHasClaimedAsync();

            // Wait for the task to complete
            while (!rewardClaimTask.IsCompleted)
                yield return null;

            if (rewardClaimTask.IsCompletedSuccessfully)
            {
                Debug.Log($"Reward Claimed");
            }
            else
            {
                Debug.Log($"Reward could not be claim");
            }
        }

        public IEnumerator GetPlayerScoreCoroutine(Action<uint> onScoreRetrieved)
        {
            Debug.Log("Retrieving Game Data...");
            Task<uint> fetchScoreTask = GetPlayerScoreAsync();

            // Wait for the task to complete
            while (!fetchScoreTask.IsCompleted)
                yield return null;

            if (fetchScoreTask.IsCompletedSuccessfully)
            {
                uint score = fetchScoreTask.Result;
                Debug.Log($"Game score retrieved: Score: {score}");
                onScoreRetrieved?.Invoke(score);
            }
            else
            {
                Debug.LogError("Failed to retrieve score.");
                onScoreRetrieved?.Invoke(0); // or handle error
            }
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

            if (fetchTask.IsCompletedSuccessfully && fetchTask.Result != null)
            {
                gameData = fetchTask.Result;

                if (gameData.Rewarded)
                {
                    int userRank = 0;
                    StartCoroutine(RankingForReward((rank) =>
                    {
                        userRank = rank;
                        Debug.Log("rank received in callback: " + rank);
                    }));
                    // weekly board popup
                    weeklyRankingRewardManager.ShowWeeklyRewardPanel(userRank, 100);

                }
                
                Debug.Log("user rank: " + gameData.Rewarded);
            }
            else
            {
                Task<GameDataShared> registerTask = RegisteringPlayerAsync(playerName, isAvatarMale);
                while (!registerTask.IsCompleted) yield return null;

                if (registerTask.IsCompletedSuccessfully && registerTask.Result != null)
                {
                    gameData = registerTask.Result;
                }
                else
                {
                    exception = registerTask.Exception?.Message;
                }
            }

            OnRead?.Invoke(true, gameData, exception);
        }
    
        private async Task<GameDataShared> GetGameDataAsync()
        {
            return await climateClient.GetGameData();
        }

        private async Task<GameDataShared> RegisteringPlayerAsync(string name, bool isAvatarMale) {
            return await climateClient.RegisterPlayer(name, isAvatarMale);
        }

        // ========== Weekly Reward Check ==========
        private IEnumerator WeeklyReward()
        {
            Debug.Log("Checking for weekly reward...");
            Task<bool> task = WeeklyRewardCheckAsync();
            while (!task.IsCompleted) yield return null;
            Debug.Log("WeeklyReward coroutine finished.");

            if (task.IsCompletedSuccessfully)
            {
                if (task.Result)
                {
                    Debug.Log("Just distributed");
                }
                else
                {
                    Debug.Log("Not Yet distributed");
                }
            }
            else
            {
                Debug.LogError("Error getting balance: " + task.Exception);
            }
        }

        private async Task<bool> WeeklyRewardCheckAsync() {
            return await climateClient.CheckAndMaybeDistributeReward();;
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
                // ReadScore();
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


        public IEnumerator RankingForReward(Action<int> onRankRetrieved)
        {
            Debug.Log("Retrieving Reward...");
            Task<PRank> task = climateClient.GetCurrentWeeklyRanking();

            // Wait for the task to complete
            while (!task.IsCompleted)
                yield return null;

            if (task.IsCompletedSuccessfully)
            {
                int rank = task.Result.Rank;
                Debug.Log($"Game score retrieved: Score: {rank}");
                onRankRetrieved?.Invoke(rank);
            }
            else
            {
                Debug.LogError("Failed to retrieve score.");
                onRankRetrieved?.Invoke(0); // or handle error
            }
        }

        

        private IEnumerator ExecuteCurrentRankRead()
        {
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