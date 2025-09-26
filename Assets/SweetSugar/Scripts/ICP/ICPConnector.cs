using System;
using EdjCase.ICP.Candid.Models;
using UnityEngine;

namespace LoyaltyCandy  {
    public class ICPConnector : MonoBehaviour
    {
        public static ICPClient Client {get { return clientInstance; } private set{}}
        [SerializeField]
        private ICPClient icpClient;
        [SerializeField]
        private string coinsPreferenceName = "Gems";

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
        [SerializeField] private string iiCanisterId = "qhbym-qaaaa-aaaaa-aaafq-cai";
        [SerializeField] private string ledgerCanisterIdId = "ryjl3-tyaaa-aaaaa-aaaba-cai";
        [SerializeField] private string netowrkUrl = "http://localhost:8080";
        [SerializeField] private string customCanister = "";
        private Principal principal;
        public string NetowrkUrl {get { return netowrkUrl; } set {}}
        public string IICanisterId {get { return iiCanisterId; } set {}}
        public string LedgerCanisterIdId {get { return ledgerCanisterIdId; } set {}}
        public Principal CanisterPrincipal { get { if (principal == null) principal = Principal.FromText(this.customCanister); return principal; } set { } }
    }
}