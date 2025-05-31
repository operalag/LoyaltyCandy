using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ICPGetToken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private NNS_II nNS_II;
    // [SerializeField] bool timelyCheck; // implement this one if timely check is needed

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InspectChecking());
        // StartCoroutine(TimerCheck(4));
    }

    // Update is called once per frame
    void Update()
    {
    }

    // public IEnumerator TimerCheck(float seconds) // implement this one if timely check is needed 
    // {
    //     while (timelyCheck)
    //     {
    //         Task task = nNS_II.GetICPBalance();
    //         while (!task.IsCompleted) yield return null;

    //         InspectICPBalance();
    //         yield return new WaitForSeconds(seconds);
    //     }
    // }

    private IEnumerator InspectChecking()
    {
        Task task = nNS_II.GetICPBalance();
        while (!task.IsCompleted) yield return null;
        InspectICPBalance();
    }

    private void InspectICPBalance()
    {
        gemText.text = nNS_II.icpBalance.ToString();
    }
}
