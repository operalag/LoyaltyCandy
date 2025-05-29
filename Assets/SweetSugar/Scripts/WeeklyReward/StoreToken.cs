using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoreToken : MonoBehaviour
{
    private const string TokenKey = "RewardTokenBalance";

    // Start is called before the first frame update
    void Start()
    {
        //SaveRewardToken(1000000);
    }

    public void SaveRewardToken(int amount)
    {
        PlayerPrefs.SetInt(TokenKey, (int)amount);
        PlayerPrefs.Save();
    }

    public int LoadRewardToken()
    {
        return PlayerPrefs.GetInt(TokenKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
