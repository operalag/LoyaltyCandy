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

        public ICPCanisterConfig Config {get { return configuration;} private set{}}

        [SerializeField]
        private ICPCanisterConfig configuration;

        private ClimateWalletApiClient climateClient;
        private int gameBalance;
        private bool checking;        
        void Start()
        {  
            StartCoroutine(RepeatedOnlineStatusCheck());
        }

        private IEnumerator RepeatedOnlineStatusCheck()  
        {
            while (true)
            {
                yield return ExecuteOnlineStatusCheck();
                CheckCoinBalance(gameBalance);
                //yield return new WaitForSeconds(1f); 
            }
        }
     
        private IEnumerator ExecuteOnlineStatusCheck()
        {
            Debug.Log("Checking online status...");
            Task<uint> task = climateClient.Read();

            while (!task.IsCompleted)
            {
                yield return null;
            }

            if (task.IsFaulted || task.Exception != null)
            {
                Debug.LogWarning("Canister is offline");

                // Track and save the offline delta only when the canister is offline
                int currentGems = PlayerPrefs.GetInt("Gems", 0); //current gems from PlayerPrefs

                int lastKnownOnlineGem = GetLastKnownBalance(); //last known gem which is online gem

                int offlineGem = currentGems - lastKnownOnlineGem; // Calculate the offline delta

                Debug.Log($"[Offline Sync] Gem change since last online: {offlineGem} (Current: {currentGems}, Last Known: {lastKnownOnlineGem})");

                // Save the offlineGem 
                Encryptor.SaveCoins(offlineGem);

            }
            else
            {
                Debug.Log("Canister is online."  );

                ApplyOfflineGem();
            }

            yield return null;
        }


        internal void Connect(IAgent agent) {
            climateClient = new ClimateWalletApiClient(agent, configuration.CanisterPrincipal);
        }

        public void ReadScore() {
            Debug.Log("Reading score");
            StartCoroutine(ExecuteRead());
        }

        private IEnumerator ExecuteRead()
        {
            Task<uint> task = climateClient.Read();
            
            while (!task.IsCompleted) {
                yield return new WaitForEndOfFrame();
            }

            if (OnRead != null) {
                OnRead(
                    task.IsCompletedSuccessfully, 
                    task.IsCompletedSuccessfully ? task.Result : null, 
                    !task.IsCompletedSuccessfully ? task.Exception.Message : null);
            }

            yield return null;
        }

        public void SaveCoins(int coins)
        {
            gameBalance = coins;
            StartCoroutine(ExecuteSave((uint) coins));
        }

        private IEnumerator ExecuteSave(uint coins)
        {
            Task<uint> task = climateClient.Set(coins);
            
            while (!task.IsCompleted) {
                yield return new WaitForEndOfFrame();
            }

            if (OnSet != null) {
                OnSet(
                    task.IsCompletedSuccessfully, 
                    task.IsCompletedSuccessfully ? task.Result : null, 
                    !task.IsCompletedSuccessfully ? task.Exception.Message : null);
            }

            yield return null;
        }

        internal void CheckCoinBalance(int numCoins)
        {
            if (!checking) {
                gameBalance = numCoins;
                checking = true;
                OnRead += CompareBalance;
                ReadScore();
            }
        }

        private void CompareBalance(bool success, object result, string message)
        {
            OnRead -= CompareBalance;

            if (success) {
                uint icpValue = (uint) result;
                int diff = (Mathf.Sign(icpValue) > 0 ? (int) icpValue : gameBalance) - gameBalance;
               // int diff = (int)icpValue - gameBalance;
                Debug.Log("Balance check complete " + diff);

                //Save last known online balance
               SetLastKnownBalance((int)icpValue);
                
            } else {
                Debug.LogError("Error geting balance: " + message);
            }

            checking = false;
        }

        private int GetLastKnownBalance() 
        {
            return PlayerPrefs.GetInt("LastKnownOnlineBalance", gameBalance); // fallback to local gameBalance
        }

        private void SetLastKnownBalance(int balance) 
        {
            PlayerPrefs.SetInt("LastKnownOnlineBalance", balance);
            PlayerPrefs.Save();
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

            if (OnRankingReceived != null) {
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

        private void ApplyOfflineGem()
        {
            // Retrieve the offline gem saved earlier
            int offlineGem = Encryptor.LoadCoins<int>();
            if (offlineGem != 0)
            {
                // Get the current gems
                int currentGems = PlayerPrefs.GetInt("Gems", 0);

                int newGemBalance = currentGems + offlineGem;
                
                SaveCoins(newGemBalance); // Save the new gem balance to ICP

                // Reset the offline delta value
                Encryptor.SaveCoins(0);
            }

        }
    }
}
