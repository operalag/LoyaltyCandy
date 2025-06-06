using System.Collections.Generic;
using UnityEngine;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSLedger;
using System;
using UnityEngine.UI;
using System.Collections;
using LoyaltyCandy.NNSLedger.Models;
using System.Threading.Tasks;


public class NNS_II : MonoBehaviour
{
    [SerializeField] private int userID;
    internal ulong icpBalance { get; private set; }
    private IIClientWrapper iiClient;

    public GameObject registerButton;

    // Start is called before the first frame update
    void Start()
    {
        iiClient = new IIClientWrapper();
        IIUser user = new IIUser((ulong)userID);
        LoginUser(user);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterUser()
    {
        Debug.Log($"Registering new user ... ");

        // IIUser user = new IIUser(10001L);
        StartCoroutine(iiClient.RegisterCoroutine(
            onComplete: (user) =>
            {
                Debug.Log($"Registered user: {user.UserNumber} registered");
                LoginUser(user);

            },
            onError: (err) => Debug.LogError("Registration failed: " + err.Message)
        ));

    }

    public void LoginUser(IIUser user)
    {
        //logging In
        Debug.Log($"Logging in ... ");
        StartCoroutine(iiClient.LoginCoroutine(
            user,
            onComplete: () =>
            {
                Debug.Log("Login successful");
                registerButton.SetActive(false);
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


