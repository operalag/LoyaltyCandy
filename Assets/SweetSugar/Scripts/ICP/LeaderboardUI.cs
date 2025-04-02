using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoyaltyCandy;

public class LeaderboardUI : MonoBehaviour
{
    public TextMeshProUGUI[] rankTexts; 

    private ICPClient icpClient; // Reference to ICP Client

    void Start()
    {
        icpClient = FindAnyObjectByType<ICPClient>();

        if (icpClient != null)
        {
            icpClient.OnRankingReceived += UpdateLeaderboard;
            icpClient.GetRanking(0, 0); // Fetch leaderboard from Canister
        }
        else
        {
            Debug.LogError("ICPClient not found in the scene.");
        }
    }

    private void UpdateLeaderboard(bool success, object result, string message)
    {
        if (success && result is List<RankingResult> rankingList)
        {
            for (int i = 0; i < rankTexts.Length && i < rankingList.Count; i++)
            {
                rankTexts[i].text = $"{i + 1}. {rankingList[i].Name} - {rankingList[i].Gems} Gems";
            }
        }
        else
        {
            Debug.LogError("Failed to update leaderboard: " + message);
        }
    }

    private void OnDestroy()
    {
        if (icpClient != null)
        {
            icpClient.OnRankingReceived -= UpdateLeaderboard;
        }
    }
}
