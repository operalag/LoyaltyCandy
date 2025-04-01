using System;
using System.Collections.Generic;
using LoyaltyCandy;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    private ICPClient icpClient;

    void Start()
    {
        icpClient = ICPConnector.Client;
        
        icpClient.OnRankingReceived += OnRankingReceived;
    }

    public void RetrieveRanking() {
        icpClient.GetRanking(1, 1);
    }

    private void OnRankingReceived(bool success, object result, string message)
    {
        if (success) {
            // convert the result to a list of rankings
            if (result.GetType() == typeof(List<RankingResult>)) {
                List<RankingResult> rankings = (List<RankingResult>) result;
                // TODO update the UI

            } else {
                Debug.LogError(string.Format("Not a ranking result {} {}", result.GetType(), result.ToString()));
            }
        } else {
            if (!success) {
                Debug.LogError(message);
            } else {
                Debug.LogError("Error converting result to int " + result);
            }
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