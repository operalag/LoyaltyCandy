using System;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet.Models;
using UnityEngine;

public class WeeklyRankingRewardManager : MonoBehaviour
{
    private ICPClient icpClient;
    private PRank currentRank;

    private const string PoolKey = "RewardTokenPool";
    private const string LastRewardDateKey = "LastWeeklyRewardDate";
    private const string PlayerClaimKey = "LastPlayerRewardDate";
    private const int InitialRewardPool = 1000000;

    void Start()
    {
        SetupRewardPool();  
        SetupClient();       // Setup rank and ICP client
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
        if (icpClient != null)
        {
            icpClient.OnRankUpdated += OnRankUpdated;
            icpClient.GetCurrentRank(); // Triggers rank callback
        }
        else
        {
            Debug.LogError("ICPClient not found.");
        }
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
            TryDeductWeeklyPayout();     // Deduct total payout once per week
            TryGivePlayerReward(rank.Rank); // Give player their reward if eligible
        }

        else
        {
             Debug.LogError($"Invalid rank result: {result}");
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
        if (rank < 1 || rank > 10)
            return;

        if (!IsBhutanSundayNight())
            return;

        string today = GetBhutanDate();
        string lastClaim = PlayerPrefs.GetString(PlayerClaimKey, "");

        if (lastClaim == today)
        {
            Debug.Log("Player already claimed weekly reward today.");
            return;
        }

        int reward = GetRewardForRank(rank);
        if (reward <= 0)
            return;

        // Save reward to player's local token store
        int current = PlayerPrefs.GetInt("RewardTokenBalance", 0);
        PlayerPrefs.SetInt("RewardTokenBalance", current + reward);
        PlayerPrefs.SetString(PlayerClaimKey, today);
        PlayerPrefs.Save();

        Debug.Log($"Player rank {rank}: received {reward} tokens. New balance: {current + reward}");
    }

    private int GetRewardForRank(int rank)
    {
        // Reward logic based on rank position
        switch (rank)
        {
            case 1: return 100000;
            case 2: return 50000;
            case 3: return 25000;
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            return 5000;
            default: return 0;
        }
    }

    private int GetTotalWeeklyPayout()
    {
        return 100000 + 50000 + 25000 + (7 * 5000);  // 210,000 tokens

    }

    private bool IsBhutanSundayNight()
    {
        // DateTime bhutanTime = DateTime.UtcNow.AddHours(6);
        // return bhutanTime.DayOfWeek == DayOfWeek.Sunday && bhutanTime.Hour >= 21;

        DateTime bhutanTime = DateTime.Now; //PC's local time
        return bhutanTime.DayOfWeek == DayOfWeek.Thursday;
    }

    private string GetBhutanDate()
    {
        // return DateTime.UtcNow.AddHours(6).ToString("yyyyMMdd");

       return DateTime.Now.ToString("yyyyMMdd");
    }

    

   
    // public int GetTokenBalance()
    // {
    //     return PlayerPrefs.GetInt(TokenKey, 0);
    // }
}
