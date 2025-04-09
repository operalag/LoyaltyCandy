using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoyaltyCandy;
using SweetSugar.Scripts.Core;
using Unity.VisualScripting;

public class GetGemUI : MonoBehaviour
{
    public TextMeshProUGUI gemText; 
    public TextMeshProUGUI rank1Text;  
    public TextMeshProUGUI rank2Text;  
    public TextMeshProUGUI rank3Text;  

    public GameObject[] ranks;
    private ICPClient icpClient;

    // Start is called before the first frame update
    void Start()
    {
        icpClient = ICPConnector.Client;

        if (icpClient != null)
        {
            icpClient.OnRead += UpdateGemBalance;
            icpClient.OnRankingReceived += UpdateRanking; // Listen for ranking updates

            // set temp score 
            UpdateGemBalance(true, (uint) InitScript.Gems, null);
            icpClient.ReadScore(); // Fetching the current gem balance
        }
        else
        {
            Debug.Log("ICPClient not found in the scene");
        }
    }

    // Updates the gem balance in the UI
    private void UpdateGemBalance(bool success, object result, string message)
    {
        if (success && result is uint gems)
        {
            gemText.text = $"Coins: {gems}";
        }
        else
        {
            Debug.Log("Failed to fetch gem balance: " + message);
        }
    }

    // Updates the ranking information in the UI
    private void UpdateRanking(bool success, object result, string message)
    {
        if (success && result is List<RankingResult> rankings)
        {
            // Display top 3 rankings
            if (rankings.Count > 0) 
                rank1Text.text = $"{rankings[0].Name}: {rankings[0].Gems} Gems";
            if (rankings.Count > 1) 
                rank2Text.text = $"{rankings[1].Name}: {rankings[1].Gems} Gems";
            if (rankings.Count > 2) 
                rank3Text.text = $"{rankings[2].Name}: {rankings[2].Gems} Gems";

            foreach (GameObject rank in ranks) {
                rank.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Failed to fetch rankings: " + message);
        }
    }

    // Unity calls this method when the object is destroyed
    private void OnDestroy()
    {
        if (icpClient != null)
        {
            icpClient.OnRead -= UpdateGemBalance;
            icpClient.OnRankingReceived -= UpdateRanking;
        }
    }
}
