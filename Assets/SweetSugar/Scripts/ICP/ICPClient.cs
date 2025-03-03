using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.HelloClient;
using Unity.VisualScripting;
using UnityEngine;

namespace LoyaltyCandy {
    public class ICPClient : MonoBehaviour
    {
        public delegate void ResultHandler(bool success, object? result, string? message);
        public event ResultHandler OnRead;
        public event ResultHandler OnSet;

        public ICPCanisterConfig Config {get { return configuration;} private set{}}

        [SerializeField]
        private ICPCanisterConfig configuration;

        private ClimateWalletApiClient climateClient;
        private int gameBalance;
        private bool checking;

        internal void Connect(IAgent agent) {
            climateClient = new ClimateWalletApiClient(agent, configuration.CanisterPrincipal);
        }

        public void ReadScore() {
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
                Debug.Log("Balance check complete " + diff);
                
            } else {
                Debug.LogError("Error geting balance: " + message);
            }

            checking = false;
        }
    }
}
