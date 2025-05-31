using System;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet.Models;
using SweetSugar.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyRankingRewardManager : MonoBehaviour
{
    private ICPClient icpClient;
    private PRank currentRank;

    private const string PoolKey = "RewardTokenPool";
    private const string LastRewardDateKey = "LastWeeklyRewardDate";
    private const string PlayerClaimKey = "LastPlayerRewardDate";
    private const int InitialRewardPool = 1000000;

    [Header("UI Elements")]
    public GameObject rewardPanel;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI rewardText;
    public Button claimButton;

    private int rewardToDisplay = 0;

    void Start()
    {
        if (rewardPanel != null) rewardPanel.SetActive(false);
        if (claimButton != null) claimButton.onClick.AddListener(OnClaimClicked);

        SetupRewardPool();
        SetupClient();
    }

    private void SetupRewardPool()
    {
        if (!PlayerPrefs.HasKey(PoolKey))
        {
            PlayerPrefs.SetInt(PoolKey, InitialRewardPool);
            PlayerPrefs.Save();
            Debug.Log($"Initialized reward pool with {InitialRewardPool} tokens.");
        }
    }

    private void SetupClient()
    {
        icpClient = ICPConnector.Client;

        if (icpClient == null)
        {
            Debug.LogError("ICPClient not found.");
            return;
        }

        icpClient.OnRankUpdated += OnRankUpdated;
        icpClient.OnRankingReceived += OnRankUpdated;
        icpClient.GetCurrentRank(); // Get actual rank
    }
    private void OnRankUpdated(bool success, object result, string message)
    {
        if (!success)
        {
            Debug.LogError("Failed to fetch rank: " + message);
            return;
        }

        if (result is PRank rank)
        {
            currentRank = rank;
            TryDeductWeeklyPayout();
            TryGivePlayerReward(rank.Rank);
        }
        else
        {
            Debug.LogError($"Invalid rank result: {result.GetType()}");
        }
    }

    private void TryDeductWeeklyPayout()
    {
        string today = GetBhutanDate();
        string lastRewardDate = PlayerPrefs.GetString(LastRewardDateKey, "");

        if (today == lastRewardDate || !IsBhutanSundayNight())
            return;

        int pool = PlayerPrefs.GetInt(PoolKey, 0);
        int weeklyPayout = GetTotalWeeklyPayout();

        if (pool >= weeklyPayout)
        {
            PlayerPrefs.SetInt(PoolKey, pool - weeklyPayout);
            PlayerPrefs.SetString(LastRewardDateKey, today);
            PlayerPrefs.Save();
            Debug.Log($"Deducted {weeklyPayout} tokens from pool. New pool: {pool - weeklyPayout}");
        }
        else
        {
            Debug.LogWarning("Not enough tokens in reward pool.");
        }
    }

    private void TryGivePlayerReward(int rank)
    {
        if (rank < 1 || rank > 10) return;
        if (!IsBhutanSundayNight()) return;

        string today = GetBhutanDate();
        string lastClaim = PlayerPrefs.GetString(PlayerClaimKey, "");

        if (lastClaim == today)
        {
            Debug.Log("Player already claimed weekly reward today.");
            return;
        }

        rewardToDisplay = GetRewardForRank(rank);
        if (rewardToDisplay <= 0) return;

        int current = PlayerPrefs.GetInt("RewardTokenBalance", 0);
        PlayerPrefs.SetInt("RewardTokenBalance", current + rewardToDisplay);
        PlayerPrefs.SetString(PlayerClaimKey, today);
        PlayerPrefs.Save();

        Debug.Log($"Player rank {rank}: received {rewardToDisplay} tokens. New balance: {current + rewardToDisplay}");

        ShowRewardUI(rank, rewardToDisplay);
    }

    private void ShowRewardUI(int rank, int reward)
    {
        if (rankText != null) rankText.text = $"#{rank}";
        if (rewardText != null) rewardText.text = $"{reward:N0} Tokens!";
        rewardPanel?.SetActive(true);
    }

    private void OnClaimClicked()
    {
        rewardPanel?.SetActive(false);
        Debug.Log("Reward panel closed by player.");
    }

    private int GetRewardForRank(int rank)
    {
         switch (rank)
        {
            case 1: return 100000;
            case 2: return 50000;
            case 3: return 25000;
            case >= 4 and <= 10: return 5000;
            default: return 0;
        }
    }

    private int GetTotalWeeklyPayout()
    {
        return 100000 + 50000 + 25000 + (7 * 5000); // 210,000
    }

    private bool IsBhutanSundayNight()
    {
        // DateTime bhutanTime = DateTime.UtcNow.AddHours(6);
        // return bhutanTime.DayOfWeek == DayOfWeek.Sunday && bhutanTime.Hour >= 21;

        DateTime bhutanTime = DateTime.Now; //PC's local time
        return bhutanTime.DayOfWeek == DayOfWeek.Saturday;
    }

    private string GetBhutanDate()
    {
        // return DateTime.UtcNow.AddHours(6).ToString("yyyyMMdd");

       return DateTime.Now.ToString("yyyyMMdd");
    }

}
