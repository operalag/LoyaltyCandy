using System.Collections.Generic;
using UnityEngine;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSLedger;
using System;
using UnityEngine.UI;
using System.Collections;
using LoyaltyCandy.NNSLedger.Models;
using System.Threading.Tasks;
using LoyaltyCandy;
using EdjCase.ICP.Agent.Identities;


public class NNS_II : MonoBehaviour
{
    [SerializeField] private int userID;
    internal ulong icpBalance { get; private set; }
    private IIClientWrapper iiClient;

    public Button registerButton;

    [SerializeField] private ICPClient iCPClient;

    // Start is called before the first frame update
    void Start()
    {
        iiClient = new IIClientWrapper();
        LoginUser((ulong)userID);
    }

    [Tooltip("Delete registered ID folder if you start new nns")]
    public void RegisterUser()
    {
        Debug.Log($"Registering new user ... ");

        // IIUser user = new IIUser(10001L);
        StartCoroutine(iiClient.RegisterCoroutine(
            onComplete: (user) =>
            {
                Debug.Log($"Registered user: {user.UserNumber} registered");
                LoginUser(user.UserNumber);
                registerButton.enabled = false;

            },
            onError: (err) => Debug.LogError("Registration failed: " + err.Message)
        ));
    }

    public void LoginUser(ulong userNumber)
    {
        //logging In
        IIUser user = new IIUser(userNumber);
        Debug.Log($"Logging in ... ");
        Ed25519Identity identity = iiClient.data.LoadIdentity(user.UserNumber);
        iiClient.SetupAgentWithIdentity(identity);

        StartCoroutine(iiClient.LoginCoroutine(
            user,
            onComplete: () =>
            {
                Debug.Log("Login successful");
                iCPClient.Connect(iiClient.DelegateAgent);
                // Now safe to check balance
                GetICPBalance();

            },
            onError: (err) => Debug.LogError("Login failed: " + err.Message)
        ));
    }

    public Task GetICPBalance()
    {
        StartCoroutine(iiClient.ICPBalanceCoroutine(
        onComplete: (balanceCheck) =>
        {
            icpBalance = balanceCheck.ICPBalance;

            Debug.Log("Your Account Identifier (hex): " + balanceCheck.AccountIDHex);
            Debug.Log($"Updated Balance: {balanceCheck.ICPBalance} ICP");

        },
        onError: (err) => Debug.LogError("Balance Check failed: " + err.Message)
        ));
        return Task.CompletedTask;
    }
}