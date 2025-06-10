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

        public ICPCanisterConfig Config { get { return configuration; } private set { } }

        [SerializeField]
        private ICPCanisterConfig configuration;

        internal ClimateWalletApiClient climateClient;
        private int gameBalance;
        private bool checking;  
        private bool appliedOfflineGem = false;      
        void Start()
        {  
            // StartCoroutine(PeriodicNetworkStatusCheck());
        }

        private IEnumerator PeriodicNetworkStatusCheck()  
        {
            while (true)
            {
                yield return CheckNetworkStatus();
                yield return new WaitForSeconds(1f);
            }
        }
     
        private IEnumerator CheckNetworkStatus()
        {
            Task<uint> task = climateClient.Read();

            while (!task.IsCompleted)
            {
                yield return null;
            }

            if (task.IsFaulted || task.Exception != null)
            {
                Debug.LogWarning("Canister is offline");

                // Track and save the offline gem only when the canister is offline
                int currentGems = PlayerPrefs.GetInt("Gems", 0); 

                int lastKnownOnlineGem = GetLastKnownGemBalance(); //last known gem which is online gem

                int offlineGem = currentGems - lastKnownOnlineGem; 

                Encryptor.SaveCoins(offlineGem);

            }
            else
            {
                Debug.Log("Canister is online."  );

                ApplyOfflineGem();

                // Wait until SaveCoins finishes updating
                yield return new WaitUntil(() => !checking);

                //Read again to get fresh balance
                Task<uint> refreshTask = climateClient.Read();
                while (!refreshTask.IsCompleted)
                {
                    yield return null;
                }

                if (refreshTask.IsCompletedSuccessfully)
                {
                    gameBalance = (int)refreshTask.Result;

                // Save updated online value
                SetLastKnownBalance(gameBalance);

                
                // Avoid checking again right after applying offline gems
                if (!appliedOfflineGem)
                {
                    CheckCoinBalance(gameBalance); // Only now compare local vs online
                }

                appliedOfflineGem = false; // reset

                }
            }

            yield return null;
        }


        internal void Connect(IAgent agent)
        {
            climateClient = new ClimateWalletApiClient(agent, Config.CanisterPrincipal);
            if (OnICPClientReady != null) OnICPClientReady();
            
            StartCoroutine(PeriodicNetworkStatusCheck());
        }

        public void ReadScore() {
            StartCoroutine(ExecuteRead());
        }

        private IEnumerator ExecuteRead()
        {
            Task<uint> task = climateClient.Read();
        
            
            while (!task.IsCompleted)
            {
                yield return new WaitForEndOfFrame();
            }

            if (OnRead != null)
            {
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
               // Debug.Log("Balance check complete " + diff);

                //Save last known online balance
               SetLastKnownBalance((int)icpValue);
                
            } else {
                Debug.LogError("Error geting balance: " + message);
            }

            checking = false;
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

        private void ApplyOfflineGem()
        {
            // Retrieve the offline gem saved earlier
            int offlineGems = Encryptor.LoadCoins<int>();
            if (offlineGems != 0)
            {
                int lastKnownGem = PlayerPrefs.GetInt("LastKnownOnlineGemBalance", 0);

                int newGemBalance = offlineGems + lastKnownGem;
                
                SaveCoins(newGemBalance); // Save the new gem balance to ICP

                // Reset the offline gem value
                Encryptor.SaveCoins(0);
                appliedOfflineGem = true;
            }

        }
    }
}
