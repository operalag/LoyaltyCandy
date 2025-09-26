using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyReward : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject WeeklyrewardPanel;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI rewardText;
    public Button claimButton;

    // Start is called before the first frame update
    void Start()
    {
        if (WeeklyrewardPanel != null) WeeklyrewardPanel.SetActive(false);
        if (claimButton != null) claimButton.onClick.AddListener(OnClaimClicked);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnClaimClicked()
    {
        WeeklyrewardPanel?.SetActive(false);
        Debug.Log("Reward panel closed by player.");
    }
}
