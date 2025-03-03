using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.HelloClient;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace LoyaltyCandy  {
    public class ICPConnector : MonoBehaviour
    {
        public static ICPClient Client {get { return clientInstance; } private set{}}

        [SerializeField]
        private TMP_Text greetingLabel;
        [SerializeField]
        private ICPCanisterConfig testConfig;
        [SerializeField]
        private ICPClient icpClient;
        [SerializeField]
        private string coinsPreferenceName = "Gems";

        private HelloClientApiClient client;
        private static ICPClient clientInstance;

        private void Awake()
        {
            if (clientInstance != null)
            {
                Destroy(gameObject);
                return;
            }
            clientInstance = icpClient;
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            ConnectTest();
            ConnectClient();
            SetupCoins();
        }

        private void SetupCoins()
        {
            int numCoins = PlayerPrefs.GetInt(coinsPreferenceName);
            icpClient.CheckCoinBalance(numCoins);
        }

        private void ConnectClient()
        {
            try
            {
                Uri network = new Uri(icpClient.Config.NetworkURL);
                HttpAgent agent = new HttpAgent(null, network);
                icpClient.Connect(agent);
            }
            catch (UriFormatException e)
            {
                Debug.LogError("Incorrect network url: " + testConfig.NetworkURL);
            }
            catch (Exception e)
            {
                Debug.LogError("Error setting up ICP client." + e.Message);
            }
        }

        private void ConnectTest()
        {
            try
            {
                Uri network = new Uri(testConfig.NetworkURL);
                HttpAgent agent = new HttpAgent(null, network);
                client = new HelloClientApiClient(agent, testConfig.CanisterPrincipal);
            }
            catch (UriFormatException e)
            {
                Debug.LogError("Incorrect network url: " + testConfig.NetworkURL);
            }
            catch (Exception e)
            {
                Debug.LogError("Error setting up ICP client." + e.Message);
            }
        }

        public void GetGreeting(string message) {
            StartCoroutine(ExecuteGreeting(message));
        }

        private IEnumerator ExecuteGreeting(string message)
        {
            Task<string> task = client.Greet(message);
            
            while (!task.IsCompleted) {
                yield return new WaitForEndOfFrame();
            }

            if (task.IsCompletedSuccessfully) {
                if (greetingLabel != null) {
                    greetingLabel.text = task.Result;
                } else {
                    Debug.Log(task.Result);
                }
            } else {
                if (greetingLabel != null) {
                    greetingLabel.text = task.Exception.Message;
                } else {
                    Debug.LogError(task.Exception.Message);
                }
            }
        }
    }

    [Serializable]
    public class ICPCanisterConfig {
        [SerializeField]
        private string networkUrl = "http://localhost:4943";
        [SerializeField]
        private string canisterId = "br5f7-7uaaa-aaaaa-qaaca-cai";

        private Principal principal;

        public string NetworkURL {get { return networkUrl; } set {}}
        public Principal CanisterPrincipal {get { if (principal == null) principal = Principal.FromText(this.canisterId); return principal;} set {}}

    }


}

