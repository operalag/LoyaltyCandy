using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ICPGetToken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private NNS_II nNS_II;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        InspectICPBalance();
    }

    private void InspectICPBalance()
    {
        gemText.text = nNS_II.icpBalance.ToString();
    }
}
