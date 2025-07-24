using System;
using System.Collections.Generic;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet.Models;
using SweetSugar.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyRankingRewardManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject WeeklyrewardPanel;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI rewardText;
    public Button claimButton;

    void Start()
    {
        if (WeeklyrewardPanel != null) WeeklyrewardPanel.SetActive(false);
        if (claimButton != null) claimButton.onClick.AddListener(OnClaimClicked);
    }

   public void ShowWeeklyRewardPanel(int rank, string rewardAmount)
    {
        if (rankText != null) rankText.text = $"#{rank}";
        if (rewardText != null) rewardText.text = $"{rewardAmount:N0} Tokens!";
        WeeklyrewardPanel?.SetActive(true);
    }


    private void OnClaimClicked()
    {
        if (WeeklyrewardPanel != null) WeeklyrewardPanel.SetActive(false);
        Debug.Log("Reward panel closed by player.");
        ICPClient icpClient = FindObjectOfType<ICPClient>();
        icpClient.ClaimReward();
    }
}
