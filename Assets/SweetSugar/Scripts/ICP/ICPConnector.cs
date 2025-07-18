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

        // [SerializeField]
        // private TMP_Text greetingLabel;
        // [SerializeField]

        [SerializeField]
        private ICPClient icpClient;
        [SerializeField]
        private string coinsPreferenceName = "Gems";

        // private HelloClientApiClient client;
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
            icpClient.OnICPClientReady += SetupCoins;
        }

        private void SetupCoins()
        {
            int numCoins = PlayerPrefs.GetInt(coinsPreferenceName);
            icpClient.CheckCoinBalance(numCoins);
            icpClient.OnICPClientReady -= SetupCoins;
        }

    }

    [Serializable]
    public class ICPCanisterConfig {

        [SerializeField]
        private string canisterId = "";

        private Principal principal;

        public Principal CanisterPrincipal {get { if (principal == null) principal = Principal.FromText(this.canisterId); return principal;} set {}}

    }


}

