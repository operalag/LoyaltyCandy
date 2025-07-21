using System;
using System.Collections;
using System.Collections.Generic;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private ICPClient icpClient;
    [SerializeField]
    private Button setButton;
    [SerializeField]
    private TMP_InputField setInput;
    [SerializeField]
    private TMP_Text scoreLabel;

    void Start()
    {
        icpClient.OnRead += UpdateUI;
        icpClient.OnSet += UpdateUI;
    }

    // private void UpdateUI(bool success, object result, string message)
    // {
    //     setInput.enabled = true;
    //     setButton.enabled = true;

    //     scoreLabel.text = success ? result.ToString() : message;
    // }
    
    private void UpdateUI(bool success, object result, string message)
    {
        GameDataShared gameDataShared = result as GameDataShared;
        setInput.enabled = true;
        setButton.enabled = true;

        scoreLabel.text = success ? gameDataShared.Score.ToString() : message;
    }

    public void SaveScore()
    {
        setButton.enabled = false;
        icpClient.SaveCoins(int.Parse(setInput.text));
    }
}
