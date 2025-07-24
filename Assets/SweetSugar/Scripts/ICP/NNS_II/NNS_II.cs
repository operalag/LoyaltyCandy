using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using LoyaltyCandy;
using EdjCase.ICP.Agent.Identities;
using GemEncryption;
using System;

public class NNS_II : MonoBehaviour
{
    [Header("Config and Dependencies")]
    [SerializeField] private ICPCanisterConfig configuration;
    public ICPCanisterConfig Config => configuration;

    [SerializeField] private ICPClient iCPClient;
    [SerializeField] private Button registerButton;

    [Tooltip("This is used as a fallback if no player ID is found in storage.")]
    [SerializeField] private int userID;

    private IIClientWrapper iiClient;
    private Coroutine registerCoroutine;
    
    private ulong userNumber;


    // Start is called before the first frame update
    void Start()
    {
        iiClient = new IIClientWrapper(Config.NetowrkUrl, Config.IICanisterId, Config.LedgerCanisterIdId);
        CheckUserNumber();
        LoginUser(userNumber);
    }

    [Tooltip("Delete registered ID folder if you start new nns")]
    public void RegisterUser()
    {
        if (registerCoroutine != null) return;
        registerButton.interactable = false;
        Debug.Log($"Registering new user ... ");

        registerCoroutine = StartCoroutine(iiClient.RegisterCoroutine(
            onComplete: (user) =>
            {
                ulong userNumber = user.UserNumber;
                Encryptor.Save(userNumber, "player");
                Debug.Log($"Registered user: {userNumber} registered");

                LoginUser(user.UserNumber);
            },
            onError: (err) =>
            {
                Debug.LogError("Registration failed: " + err.Message);
                registerButton.interactable = true;
                registerCoroutine = null;
            }
        ));
    }

    public void LoginUser(ulong userNumber)
    {
        //logging In
        Debug.Log($"Logging in ... ");

        IIUser user = new IIUser(userNumber);
        Ed25519Identity identity = iiClient.data.LoadIdentity(user.UserNumber);
        iiClient.SetupAgentWithIdentity(identity);

        StartCoroutine(iiClient.LoginCoroutine(
            user,
            onComplete: () =>
            {
                Debug.Log("Login successful");
                iCPClient.Connect(iiClient.DelegateAgent, Config.CanisterPrincipal);
                registerButton.gameObject.SetActive(false);
            },
            onError: (err) =>
            {
                Debug.LogError("Login failed: " + err.Message);
                registerButton.gameObject.SetActive(true);
            }
        ));
    }

    private void CheckUserNumber()
    {
        try
        {
            userNumber = Encryptor.Load<ulong>("player");
        }
        catch (Exception e)
        {
            Debug.LogError($"User file no found: {e.Message}");
        }

        Debug.Log($"user number: {userNumber}");

        if (userNumber == 0)
        {
            userNumber = (ulong)userID;
        }
    }
}