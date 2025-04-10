using System;
using System.Collections.Generic;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet.Models;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    private ICPClient icpClient;
    private PRank currentRank;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        if (icpClient == null) {
            icpClient = ICPConnector.Client;
            icpClient.OnRankUpdated += OnRankUpdated;
        }

        if (currentRank == null) {
            icpClient.GetCurrentRank();
        }
    }

    private void OnRankUpdated(bool success, object result, string message)
    {
        if (success) {
            // convert the result to a list of rankings
            if (result.GetType() == typeof(PRank)) {
                currentRank = (PRank)result;
                icpClient.GetRanking(1, 1, currentRank.Rank);
            } else {
                Debug.LogError(string.Format("Not a rank result {} {}", result.GetType(), result.ToString()));
            }
        } else {
            if (!success) {
                Debug.LogError(message);
            } else {
                Debug.LogError("Error converting result to int " + result);
            }
        }
    }

    public void RetrieveRanking() {
        if (icpClient != null) {
            icpClient.GetCurrentRank();
        }
    }

}

public class RankingResult {
    public string Name {get; private set;}
    public int Ranking {get; private set; }
    public int Gems {get; private set; }

    public RankingResult(string name, int ranking, int gems) {
        Name = name;
        Ranking = ranking;
        Gems = gems;
    }
}