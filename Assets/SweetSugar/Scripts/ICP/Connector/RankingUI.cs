using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoyaltyCandy;
using Unity.VisualScripting;

public class RankingUI : MonoBehaviour
{
    public TextMeshProUGUI RankingOne;
    public TextMeshProUGUI RankingTwo;
    public TextMeshProUGUI RankingThree;
    public TextMeshProUGUI CurrentBalanceText;

    private ICPClient iCPClient;  // reference to icp client

    // Start is called before the first frame update
    void Start()
    {
        iCPClient = FindAnyObjectByType<ICPClient>();
        iCPClient.OnRankingReceived += UpdateRankingUI;
        iCPClient.OnRead += UpdateRankingUI; // listen when balence is fetched
        iCPClient.ReadScore(); // fetch current balane

    }

    private void UpdateRankingUI(bool success, object result, string message)
    {
        if (success)
        {
            if (result is List<RankingResult> rankingList)
            {
                // top 3 ranking
                if (rankingList.Count > 0)
                        RankingOne.text = $"{rankingList[0].Name}: {rankingList[0].Gems} Gems";

                if (rankingList.Count > 1)
                    RankingTwo.text = $"{rankingList[1].Name}: {rankingList[1].Gems} Gems";

                if (rankingList.Count > 2)
                    RankingThree.text = $"{rankingList[2].Name}: {rankingList[2].Gems} Gems"; ;
            }

            else
            {
                Debug.Log("Result is not a list");
            }

        
        }

        else
        {
            Debug.Log("Fail to retrive ranking " + message);
        }
    }

    private void UpdateBalanceUI(bool success, object result, string message)
    {
        if (success)
        {
            uint balance = (uint)result;
            CurrentBalanceText.text = $"Current Balance: {balance} Gems";
        }

        else
        {
            Debug.Log("Fauled to get current balance");
        }
    }

    private void Oestroy()
    {
        iCPClient.OnRankingReceived -= UpdateRankingUI;
        iCPClient.OnRead -= UpdateBalanceUI;
    }
}
