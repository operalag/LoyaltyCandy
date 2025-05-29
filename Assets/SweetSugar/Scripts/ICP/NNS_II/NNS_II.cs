using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EdjCase.ICP.Agent.Agents;
// using EdjCase.ICP.Agent.Models;
using EdjCase.ICP.Agent.Identities;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using System.Security.Cryptography;


public class NNS_II : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void RegisterUser()
    {
        // read user id from command line
        // if no user then register
        // IIUser user = iiClient.Register();

        IIClientWrapper iiClient = new IIClientWrapper();

        IIUser user = new IIUser(10001L);
        Debug.Log($"Login in User {user.UserNumber}");
        iiClient.Login(user);


        //check balace
        Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
        NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);
        Debug.Log("Ledger Client canister: " + ledgerClient.CanisterId);

        List<byte> accountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());
        AccountBalanceArgs balanceRequest = new AccountBalanceArgs(accountIdentifier);
        Tokens balance = await ledgerClient.AccountBalance(balanceRequest);

        Debug.Log("Balance: " + balance.E8s + " e8s");
    }

    public void CheckBalance()
    {

    }
    




}
