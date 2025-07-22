using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Agents;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;
using UnityEngine;
using GemEncryption;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy
{
    public class ICPClient : MonoBehaviour
    {
        #region Data Structures
        public struct RewardInfo
        {
            public string rewardAmount;
            public int weeklyRank;

            public RewardInfo(string rewardAmount, int weeklyRank)
            {
                this.rewardAmount = rewardAmount;
                this.weeklyRank = weeklyRank;
            }
        }
        #endregion

        #region Events
        public delegate void ResultHandler(bool success, object? result, string? message);
        public event ResultHandler OnRead;
        public event ResultHandler OnSet;
        public event ResultHandler OnRankingReceived;
        public event ResultHandler OnRankUpdated;

        public delegate void ICPClientReady();
        public event ICPClientReady OnICPClientReady;
        #endregion

        #region Configuration & State

        internal ClimateWalletApiClient climateClient;
        [SerializeField] private WeeklyRankingRewardManager weeklyRankingRewardManager;

        private Coroutine networkMonitorCoroutine;
        private int gameBalance;
        private bool isChecking;
        private bool appliedOfflineGem = false;

        #endregion

        #region Initialization & Connection

        internal void Connect(IAgent agent, Principal canisterId)
        {
            climateClient = new ClimateWalletApiClient(agent, canisterId);

            // Show canister address on connect
            StartCoroutine(GetCanisterAddressHexCoroutine());

            CheckPlayerData();

            OnICPClientReady?.Invoke();

            if (networkMonitorCoroutine != null)
                StopCoroutine(networkMonitorCoroutine);

            networkMonitorCoroutine = StartCoroutine(MonitorNetworkStatus());
        }

        private IEnumerator MonitorNetworkStatus(float timeoutSeconds = 5f)
        {
            Debug.Log("Testing canister...");
            Task pingTask = climateClient.Ping();
            float startTime = Time.time;

            while (!pingTask.IsCompleted)
            {
                if (Time.time - startTime > timeoutSeconds)
                {
                    Debug.LogWarning("Timeout: Canister didn't respond in time.");
                    yield break;
                }
                yield return null;
            }

            if (pingTask.IsFaulted || pingTask.Exception != null)
            {
                Debug.LogWarning("Canister is OFFLINE");
                Debug.LogWarning("Reason: " + pingTask.Exception?.Message);
                HandleOfflineMode();
            }
            else
            {
                Debug.Log("Canister is ONLINE");
                ApplyOfflineGem();
                yield return new WaitUntil(() => !isChecking);

                StartCoroutine(GetPlayerScoreCoroutine(score =>
                {
                    gameBalance = (int)score;
                    Debug.Log("Score received in callback: " + score);
                }));

                SetLastKnownBalance(gameBalance);

                if (!appliedOfflineGem)
                    CheckCoinBalance(gameBalance);

                appliedOfflineGem = false;
            }
            Debug.Log("Testing Completed");
        }

        #endregion

        #region Offline Handling

        private void HandleOfflineMode()
        {
            int currentGems = PlayerPrefs.GetInt("Gems", 0);
            int lastKnownOnlineGem = GetLastKnownGemBalance();
            int offlineGem = currentGems - lastKnownOnlineGem;
            Encryptor.SaveCoins(offlineGem);
        }

        private void ApplyOfflineGem()
        {
            int offlineGems = Encryptor.LoadCoins<int>();
            if (offlineGems != 0)
            {
                int lastKnownGem = PlayerPrefs.GetInt("LastKnownOnlineGemBalance", 0);
                int newGemBalance = offlineGems + lastKnownGem;
                SaveCoins(newGemBalance);
                Encryptor.SaveCoins(0);
                appliedOfflineGem = true;
            }
        }

        private int GetLastKnownGemBalance()
        {
            return PlayerPrefs.GetInt("LastKnownOnlineGemBalance", gameBalance);
        }

        private void SetLastKnownBalance(int balance)
        {
            PlayerPrefs.SetInt("LastKnownOnlineGemBalance", balance);
            PlayerPrefs.Save();
        }

        #endregion

        #region Score & Coin Management

        public void SaveCoins(int coins)
        {
            gameBalance = coins;
            StartCoroutine(UpdatingPlayerScoreCoroutine(coins));
        }

        public IEnumerator GetPlayerScoreCoroutine(Action<uint> onScoreRetrieved)
        {
            Debug.Log("Retrieving score...");
            Task<uint> fetchScoreTask = GetPlayerScoreAsync();

            while (!fetchScoreTask.IsCompleted)
                yield return null;

            if (fetchScoreTask.IsCompletedSuccessfully)
            {
                uint score = fetchScoreTask.Result;
                Debug.Log($"Game score retrieved: {score}");
                onScoreRetrieved?.Invoke(score);
            }
            else
            {
                Debug.LogError("Failed to retrieve score.");
                onScoreRetrieved?.Invoke(0);
            }
        }

        private async Task<uint> GetPlayerScoreAsync()
        {
            return await climateClient.ReadScore();
        }

        public IEnumerator UpdatingPlayerScoreCoroutine(int score)
        {
            Task updatingScore = updatePlayerScoreAsync(score);
            while (!updatingScore.IsCompleted)
                yield return null;

            OnSet?.Invoke(
                updatingScore.IsCompletedSuccessfully,
                updatingScore.IsCompletedSuccessfully ? updatingScore : null,
                !updatingScore.IsCompletedSuccessfully ? updatingScore.Exception?.Message : null);
        }

        private async Task updatePlayerScoreAsync(int score)
        {
            await climateClient.UpdatePlayerScore((uint)score);
        }

        internal void CheckCoinBalance(int numCoins)
        {
            if (!isChecking)
            {
                gameBalance = numCoins;
                isChecking = true;
                OnRead += CompareBalance;
            }
        }

        private void CompareBalance(bool success, object result, string message)
        {
            OnRead -= CompareBalance;

            if (success)
            {
                GameDataShared gameShareData = (GameDataShared)result;
                int gemValue = (int)gameShareData.Score;
                int icpGem = Mathf.Sign(gemValue) > 0 ? gemValue : gameBalance;
                int diff = icpGem - gameBalance;
                SetLastKnownBalance(diff);
            }
            else
            {
                Debug.LogError("Error getting balance: " + message);
            }
            isChecking = false;
        }

        #endregion

        #region Player Data & Rewards

        public void CheckPlayerData()
        {
            StartCoroutine(GetOrRegisterGameDataCoroutine());
            StartCoroutine(WeeklyReward());
        }

        public IEnumerator GetOrRegisterGameDataCoroutine(string playerName = "Player", bool isAvatarMale = true)
        {
            Task<GameDataShared> fetchTask = GetGameDataAsync();
            while (!fetchTask.IsCompleted) yield return null;

            GameDataShared gameData = new GameDataShared();
            string exception = "";

            if (fetchTask.IsCompletedSuccessfully && fetchTask.Result != null)
            {
                gameData = fetchTask.Result;

                if (gameData.Rewarded)
                {
                    StartCoroutine(GetRewardInfoCoroutine(result =>
                    {
                        Debug.Log("rank received in callback: " + result.weeklyRank);
                        Debug.Log("reward amount received in callback: " + result.rewardAmount);

                        // Show weekly reward panel
                        weeklyRankingRewardManager.ShowWeeklyRewardPanel(result.weeklyRank, result.rewardAmount);
                    }));
                }
            }
            else
            {
                Task<GameDataShared> registerTask = RegisteringPlayerAsync(playerName, isAvatarMale);
                while (!registerTask.IsCompleted) yield return null;

                if (registerTask.IsCompletedSuccessfully && registerTask.Result != null)
                    gameData = registerTask.Result;
                else
                    exception = registerTask.Exception?.Message;
            }

            OnRead?.Invoke(true, gameData, exception);
        }

        private async Task<GameDataShared> GetGameDataAsync()
        {
            return await climateClient.GetGameData();
        }

        private async Task<GameDataShared> RegisteringPlayerAsync(string name, bool isAvatarMale)
        {
            return await climateClient.RegisterPlayer(name, isAvatarMale);
        }

        private IEnumerator WeeklyReward()
        {
            Debug.Log("Checking for weekly reward...");
            Task<bool> task = WeeklyRewardCheckAsync();
            while (!task.IsCompleted) yield return null;
            Debug.Log("WeeklyReward coroutine finished.");

            if (task.IsCompletedSuccessfully)
            {
                if (task.Result) Debug.Log("Just distributed");
                else Debug.Log("Not Yet distributed");
            }
            else
            {
                Debug.LogError("Error : " + task.Exception);
            }
        }

        private async Task<bool> WeeklyRewardCheckAsync()
        {
            return await climateClient.CheckAndMaybeDistributeReward();
        }

        #endregion

        #region Reward & Ranking Coroutines

        public IEnumerator GetRewardInfoCoroutine(Action<RewardInfo> onRewardInfoRetrieved)
        {
            Task<string> rewardTask = GetRewardAmountAsync();
            Task<GameDataShared> gameDataTask = GetGameDataAsync();

            while (!rewardTask.IsCompleted || !gameDataTask.IsCompleted)
                yield return null;

            if (rewardTask.IsCompletedSuccessfully && gameDataTask.IsCompletedSuccessfully)
            {
                string rewardAmount = rewardTask.Result;
                int weeklyRank = gameDataTask.Result.WeeklyRank;

                Debug.Log($"Reward Amount: {rewardAmount}, Weekly Rank: {weeklyRank}");

                onRewardInfoRetrieved?.Invoke(new RewardInfo(rewardAmount, weeklyRank));
            }
            else
            {
                Debug.LogError("Failed to retrieve reward amount or rank.");
                onRewardInfoRetrieved?.Invoke(new RewardInfo("0", 0)); // fallback
            }
        }

        private async Task<string> GetRewardAmountAsync()
        {
            return await climateClient.ShowRewardAmount();
        }

        #endregion

        #region Canister Address

        public IEnumerator GetCanisterAddressHexCoroutine()
        {
            Debug.Log($"Retriving Climate Account ID (Hex)... ");
            Task<string> addressRetrieveTask = GetCanisterAddressHexAsync();

            while (!addressRetrieveTask.IsCompleted)
                yield return null;

            if (addressRetrieveTask.IsCompletedSuccessfully)
            {
                string addressHex = addressRetrieveTask.Result;
                Debug.Log($"Climate Account ID (Hex): {addressHex}");
            }
            else
            {
                Debug.LogError("Failed to retrieve account address.");
            }
        }

        private async Task<string> GetCanisterAddressHexAsync()
        {
            return await climateClient.GetCanisterAccountAddressHex();
        }

        #endregion

        #region Reward Claim & Weekly Reset

        private async Task RewardHasClaimedAsync()
        {
            await climateClient.RewardClaimed();
        }

        public IEnumerator RewardHasClaimedCoroutine()
        {
            Task rewardClaimTask = RewardHasClaimedAsync();
            while (!rewardClaimTask.IsCompleted)
                yield return null;

            if (rewardClaimTask.IsCompletedSuccessfully)
                Debug.Log("Reward Claimed");
            else
                Debug.Log("Reward could not be claimed");
        }

        private async Task ResetPlayerRankOnWeeklyAsync()
        {
            await climateClient.ResetPlayerWeeklyRank();
        }

        public IEnumerator ResetPlayerRankOnWeekly()
        {
            Task playerWeeklyRankTask = ResetPlayerRankOnWeeklyAsync();
            while (!playerWeeklyRankTask.IsCompleted)
                yield return null;

            if (playerWeeklyRankTask.IsCompletedSuccessfully)
                Debug.Log("Player rank on weekly removed");
            else
                Debug.LogError($"Error {playerWeeklyRankTask.Exception}");
        }

        public void ClaimReward()
        {
            StartCoroutine(RewardHasClaimedCoroutine());
            StartCoroutine(ResetPlayerRankOnWeekly());
        }

        #endregion

        #region Ranking APIs

        internal void GetCurrentRank()
        {
            StartCoroutine(ExecuteCurrentRankRead());
        }

        private IEnumerator ExecuteCurrentRankRead()
        {
            Task<PRank> task = climateClient.GetCurrentGlobalRanking();
            while (!task.IsCompleted)
                yield return new WaitForEndOfFrame();

            OnRankUpdated?.Invoke(true, task.Result, null);
        }

        internal void GetRanking(int before, int after, short rank)
        {
            StartCoroutine(ExecuteRankingRead((uint)before, (uint)after, rank));
        }

        private IEnumerator ExecuteRankingRead(uint before, uint after, short rank)
        {
            Task<ClimateWallet.Models.RankingResult> task = climateClient.GetGlobalRanking(before, after, rank);
            while (!task.IsCompleted)
                yield return new WaitForEndOfFrame();

            List<RankingResult> result = new List<RankingResult>();
            foreach (PRank pRank in task.Result.Ranking)
            {
                result.Add(new RankingResult(pRank.Name, pRank.Rank, (int)pRank.Score));
            }

            OnRankingReceived?.Invoke(true, result, null);
        }

        #endregion
    }
}