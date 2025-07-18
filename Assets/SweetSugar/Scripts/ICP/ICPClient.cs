using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;
using LoyaltyCandy.HelloClient;
using Unity.VisualScripting;
using UnityEngine;
using GemEncryption;


namespace LoyaltyCandy {
    public class ICPClient : MonoBehaviour
    {
        public delegate void ResultHandler(bool success, object? result, string? message);
        public event ResultHandler OnRead;
        public event ResultHandler OnSet;
        public event ResultHandler OnRankingReceived;
        public event ResultHandler OnRankUpdated;

        public delegate void ICPClientReady();
        public event ICPClientReady OnICPClientReady; 

        public ICPCanisterConfig Config => configuration;
        [SerializeField] private ICPCanisterConfig configuration;

        internal ClimateWalletApiClient climateClient;
        private int gameBalance;
        private bool isChecking;  
        private bool appliedOfflineGem = false;

        private Coroutine networkMonitorCoroutine;
      
        internal void Connect(IAgent agent)
        {
            climateClient = new ClimateWalletApiClient(agent, Config.CanisterPrincipal); // connecting with custom canister
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

                var getScoreTask = GetOnlineScoreSafe();
                while (!getScoreTask.IsCompleted) yield return null;

                gameBalance = getScoreTask.Result;
                SetLastKnownBalance(gameBalance);

                if (!appliedOfflineGem)
                {
                    CheckCoinBalance(gameBalance);
                }

                appliedOfflineGem = false;
            }

            Debug.Log("Testing Completed");
        }

        private async Task<int> GetOnlineScoreSafe()
        {
            try
            {
                var data = await climateClient.GetGameData();
                return (int)data.Score;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while fetching score: {e.Message}");
                return gameBalance; // fallback to current
            }
        }
        
        private void HandleOfflineMode()
        {
            int currentGems = PlayerPrefs.GetInt("Gems", 0);
            int lastKnownOnlineGem = GetLastKnownGemBalance(); //last known gem which is online gem
            int offlineGem = currentGems - lastKnownOnlineGem;
            Encryptor.SaveCoins(offlineGem);
        }

        private void ApplyOfflineGem()
        {
            int offlineGems = Encryptor.LoadCoins<int>();    // Retrieve the offline gem saved earlier
            if (offlineGems != 0)
            {
                int lastKnownGem = PlayerPrefs.GetInt("LastKnownOnlineGemBalance", 0);
                int newGemBalance = offlineGems + lastKnownGem;
                SaveCoins(newGemBalance); // Save the new gem balance to ICP
                Encryptor.SaveCoins(0); // Reset the offline gem value
                appliedOfflineGem = true;
            }
        }

        private int GetLastKnownGemBalance()
        {
            return PlayerPrefs.GetInt("LastKnownOnlineGemBalance", gameBalance); // fallback to local gameBalance
        }

        private void SetLastKnownBalance(int balance) 
        {
            PlayerPrefs.SetInt("LastKnownOnlineGemBalance", balance);
            PlayerPrefs.Save();
        }

        public void ReadScore()
        {
            StartCoroutine(GetOrRegisterGameDataCoroutine());
        }
        
        public IEnumerator GetOrRegisterGameDataCoroutine(string playerName = "Player", bool isAvatarMale = true)
        {
            Debug.Log("Retrieving Game Data...");
           
            Task<GameDataShared> fetchTask = GetGameDataAsync();
            while (!fetchTask.IsCompleted) yield return null; // Wait for the task to complete

            Debug.Log($"Retrieving Game Data Status {fetchTask.Status}");

            GameDataShared gameData = null;
            string exception = "";

            if (fetchTask.IsCompletedSuccessfully && fetchTask.Result != null)
            {
                gameData = fetchTask.Result;
                Debug.Log($"Game data retrieved: {gameData.Name} | Score: {gameData.Score}");
            }
            else
            {
                Debug.Log($"Game data not found or failed. Attempting to register player '{playerName}'...");

                Task<GameDataShared> registerTask = RegisteringPlayerAsync(playerName, isAvatarMale);
                while (!registerTask.IsCompleted) yield return null;
                Debug.Log($"Player registration status {registerTask.Status}");

                if (registerTask.IsCompletedSuccessfully && registerTask.Result != null)
                {
                    gameData = registerTask.Result;
                    Debug.Log($"Player registered: {gameData.Name} | Score: {gameData.Score}");
                }
                else
                {
                    Debug.LogError($"Registration failed: {registerTask.Exception?.Message}");
                    exception = registerTask.Exception?.Message;
                }
            }
          
            OnRead?.Invoke(
                gameData != null,
                gameData,
                exception != null ? exception : null
            );
        }

        private async Task<GameDataShared> GetGameDataAsync()
        {
            return await climateClient.GetGameData();
        }

        private async Task<GameDataShared> RegisteringPlayerAsync(string name , bool isAvatarMale)
        {
            return await climateClient.RegisterPlayer(name, isAvatarMale);
        }
        
        public IEnumerator UpdatingPlayerScoreCoroutine(int score)
        {
            Task updatingScore = updatePlayerScoreAsync(score);
          
            while (!updatingScore.IsCompleted) yield return null;

            if (OnSet != null)
            {
                OnSet(
                    updatingScore.IsCompletedSuccessfully,
                    updatingScore.IsCompletedSuccessfully ? updatingScore : null,
                    !updatingScore.IsCompletedSuccessfully ? updatingScore.Exception.Message : null);
            }
            yield return null;
        }

        private async Task updatePlayerScoreAsync(int score)
        {
            Debug.Log($"Updating score by: {score}");
            await climateClient.UpdatePlayerScore((uint)score);
           
        }
        
        public void SaveCoins(int coins)
        {
            gameBalance = coins;
            StartCoroutine(UpdatingPlayerScoreCoroutine(coins));
        }

        internal void CheckCoinBalance(int numCoins)
        {
            if (!isChecking)
            {
                gameBalance = numCoins;
                isChecking = true;
                OnRead += CompareBalance;
                ReadScore();
            }
        }

        private void CompareBalance(bool success, object result, string message)
        {
            OnRead -= CompareBalance;

            if (success)
            {
                GameDataShared gameShareData = (GameDataShared) result;
                
                int gemValue = (int)gameShareData.Score;
                int icpGem = Mathf.Sign(gemValue) > 0 ? (int)gemValue : gameBalance;
                int diff = icpGem - gameBalance;

                //Save last known online balance
                SetLastKnownBalance(diff);

            }
            else
            {
                Debug.LogError("Error geting balance: " + message);
            }

            isChecking = false;
        }

        internal void GetCurrentRank()
        {
            StartCoroutine(ExecuteCurrentRankRead());
        }

        private IEnumerator ExecuteCurrentRankRead()
        {
            Debug.Log("Reading current rank");
            Task<PRank> task = climateClient.GetCurrentRanking();
            while (!task.IsCompleted) {
                yield return new WaitForEndOfFrame();
            }

            if (OnRankUpdated != null) {
                OnRankUpdated(true, task.Result, null);
            }
            yield return null;
        }

        internal void GetRanking(int before, int after, short rank)
        {
            StartCoroutine(ExecuteRankingRead((uint)before, (uint)after, rank));
        }

        private IEnumerator ExecuteRankingRead(uint before, uint after, short rank)
        {
            List<RankingResult> result = new List<RankingResult>();

            Debug.Log("Reading ranking");
            Task<ClimateWallet.Models.RankingResult> task = climateClient.GetRanking(before, after, rank);
            while (!task.IsCompleted) {
                yield return new WaitForEndOfFrame();
            }

            foreach (PRank pRank in task.Result.Ranking) {
                result.Add(new RankingResult(pRank.Name, pRank.Rank, (int)pRank.Score));
            }

            if (OnRankingReceived != null) {
                OnRankingReceived(true, result, null);
            }

            yield return null;
        }
    }
}