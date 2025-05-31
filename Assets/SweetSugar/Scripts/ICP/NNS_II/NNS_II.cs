using System.Collections.Generic;
using UnityEngine;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSLedger;
using System;
using UnityEngine.UI;
using System.Collections;


public class NNS_II : MonoBehaviour
{
    private IIClientWrapper iiClient;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterUser()
    {
        Debug.Log($"Started ");
        iiClient = new IIClientWrapper();
    
                // IIUser user = new IIUser(10001L);
        StartCoroutine(iiClient.RegisterCoroutine(
            onComplete: (user) =>
            {
                Debug.Log($"Registered user: {user.UserNumber} registered");

                //logging In
                StartCoroutine(iiClient.LoginCoroutine(
                    user,
                    onComplete: () =>
                    {
                        Debug.Log("Login successful");

                        // Now safe to check balance
                        Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
                        NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);
                        Debug.Log("Ledger Client canister: " + ledgerClient.CanisterId);

                        List<byte> accountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());
                        string accountHex = BitConverter.ToString(accountIdentifier.ToArray()).Replace("-", "").ToLowerInvariant();
                        Debug.Log("Your Account Identifier (hex): " + accountHex);

                    } ,
                    onError: (err) => Debug.LogError("Login failed: " + err.Message)
                ));
            },
            onError: (err) => Debug.LogError("Registration failed: " + err.Message)
        ));


   

  
  




        
        
       

        

    }


  
   
}
