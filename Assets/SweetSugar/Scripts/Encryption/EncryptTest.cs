using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GemEncryption;

public class EncryptTest : MonoBehaviour
{
    public int val;
    // Start is called before the first frame update
    void Start()
    {
        Encryptor.OnFailDecryption += OnErrorDecryption;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetString("Gemss", val.ToString());
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Encryptor.Save(val);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            int val;
            val = Encryptor.Load<int>();

            Debug.Log($"Loaded data: {val}" );
        }

    }



    void OnErrorDecryption()
    {
        Debug.Log("Modified file");
    }
}
