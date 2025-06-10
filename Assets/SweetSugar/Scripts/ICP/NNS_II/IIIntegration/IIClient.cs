using EdjCase.ICP.Agent.Identities;
using EdjCase.ICP.Agent;
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using EdjCase.ICP.Agent.Models;
using LoyaltyCandy.InternetIdentity;
using LoyaltyCandy.InternetIdentity.Models;
using System.Linq;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using Unity.VisualScripting.Antlr3.Runtime;

class SetupData
{
    // public Ed25519Identity SessionKey { get; set; }
    // public DeviceData DeviceData
    // {
    //     get
    //     {
    //         return GenerateOrGetDD(GenerateOrGetDeviceKey().PublicKey.ToDerEncoding());
    //     }

    //     private set { }
    // }
    // private DeviceData deviceData;
    private Ed25519Identity identity;
    public string FrontendHostname { get { return "http://localhost:8080"; } set { } }

    // private DeviceData GenerateOrGetDD(byte[] pubKey)
    // {
    //     if (deviceData == null)
    //     {
    //         deviceData = new DeviceData
    //         {
    //             Alias = "MyDevice",
    //             Pubkey = pubKey.ToList<byte>(),
    //             KeyType = KeyType.SeedPhrase, // Optional
    //             Purpose = Purpose.Authentication,
    //             CredentialId = null,
    //             Protection = DeviceProtection.Unprotected
    //         };
    //     }

    //     return deviceData;
    // }

    internal Ed25519Identity GenerateOrGetDeviceKey()
    {
        if (identity == null)
        {
            // try load from disk if not then generate
            identity = Ed25519Identity.Generate();
            // Save to disk;
        }
        return identity;
    }
    
    internal void SaveIdentity(ulong userNumber, byte[] privateKeyBytes)
    {
        // string directory = "identityData"; // Subfolder name
        // Directory.CreateDirectory(directory); // Create if it doesn't exist
        string path = Path.Combine(Application.persistentDataPath, $"{userNumber}_identity.key");

        // string path = Path.Combine(directory, $"{userNumber}_identity.key");
        string base64Key = Convert.ToBase64String(privateKeyBytes);
        File.WriteAllText(path, base64Key);
    }

    internal Ed25519Identity LoadIdentity(ulong userNumber)
    {
        // string directory = "identityData"; // Subfolder name
        // string path = Path.Combine(directory, $"{userNumber}_identity.key");
        string path = Path.Combine(Application.persistentDataPath, $"{userNumber}_identity.key");
        
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Identity file not found for user {userNumber}");
        }

        string base64Key = File.ReadAllText(path);
        byte[] privateKeyBytes = Convert.FromBase64String(base64Key);
        return Ed25519Identity.FromPrivateKey(privateKeyBytes);
    }

    // internal Ed25519Identity LoadIdentity()
    // {
    //     string identityPath = Path.Combine(Application.persistentDataPath, "identity.key");

    //     bool dataExist = PlayerPrefs.HasKey("It_Is_You");
    //     // if (identity == null && File.Exists(identityPath))
    //     if (identity == null && dataExist)
    //     {
    //         // Read the base64-encoded key from file
    //         // string base64Key = File.ReadAllText(identityPath);
    //         string base64Key = PlayerPrefs.GetString("It_Is_You");

    //         // Convert it back to bytes
    //         byte[] privateKeyBytes = Convert.FromBase64String(base64Key);

    //         // Re-create identity
    //         identity = Ed25519Identity.FromPrivateKey(privateKeyBytes);
    //     }
    //     else if (identity == null)
    //     {
    //         identity = GenerateOrGetDeviceKey();
    //         // Get raw private key bytes (usually 32 bytes)
    //         byte[] privateKeyBytes = identity.PrivateKey;

    //         // Convert to base64 or hex for saving (here we use base64)
    //         string base64Key = Convert.ToBase64String(privateKeyBytes);

    //         // Save to file
    //         // File.WriteAllText(identityPath, base64Key);
    //         PlayerPrefs.SetString("It_Is_You", base64Key);
    //         PlayerPrefs.Save();
    //     }

    //     return identity;
    // } 

}

public class IIClientWrapper
{
    public HttpAgent DelegateAgent { get; private set; }
    public Principal IICanisterPrincipal { get; private set; }
    public Principal LedgerCanisterPrincipal { get; private set; }

    public InternetIdentityApiClient IIClient { get; set; }
    public NNSLedgerApiClient ledgerClient { get; set; }

    public string hostAddress { get; private set; }

    internal SetupData data = new SetupData();
    private HttpAgent Agent { get; set; }

    public IIClientWrapper(string iiCanisterId = "qhbym-qaaaa-aaaaa-aaafq-cai", string ledgerCanisterId = "ryjl3-tyaaa-aaaaa-aaaba-cai")
    {
        this.IICanisterPrincipal = Principal.FromText(iiCanisterId);
        this.LedgerCanisterPrincipal = Principal.FromText(ledgerCanisterId);

        this.hostAddress = data.FrontendHostname;

        // Temporary agent for registration
        Ed25519Identity tempIdentity = data.GenerateOrGetDeviceKey();
        this.Agent = new HttpAgent(tempIdentity, new Uri(this.hostAddress));
        this.IIClient = new InternetIdentityApiClient(Agent, IICanisterPrincipal, new CandidConverter());
        
    }

    // public HttpAgent SetupAgent(string hostAddress)
    // {
    //     // this.SessionKey = Ed25519Identity.Generate(); // Or load from existing PEM
    //     // this.PubKey = [.. SessionKey.GetPublicKey().ToDerEncoding()];
    //     return new HttpAgent(data.LoadIdentity(), new Uri(hostAddress));
    // }

     public void SetupAgentWithIdentity(Ed25519Identity identity)
    {
        this.Agent = new HttpAgent(identity, new Uri(this.hostAddress));
        this.IIClient = new InternetIdentityApiClient(this.Agent, this.IICanisterPrincipal, new CandidConverter());
    }

    private async Task<RegisterResponse.RegisteredInfo> RegisterAsync()
    {
        Challenge challenge = await IIClient.CreateChallenge();
        // Console.WriteLine("Challenge Key: " + challenge.ChallengeKey);

        // Simulate solving (for demo)
        ChallengeResult captchaResult = new ChallengeResult
        {
            Key = challenge.ChallengeKey,
            Chars = "a" // Use dummy value in dev
        };
        RegisterResponse response = await IIClient.Register(createDeviceData(), captchaResult, OptionalValue<Principal>.NoValue());
        
        return response.AsRegistered();
    }

    private DeviceData createDeviceData()
    {
        DeviceData deviceData = new DeviceData
        {
            Pubkey = data.GenerateOrGetDeviceKey().PublicKey.ToDerEncoding().ToList(),
            Alias = $"My Device {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
            CredentialId = null,
            Purpose = Purpose.Authentication,
            KeyType = KeyType.SeedPhrase,
            Protection = DeviceProtection.Unprotected
        };

        // this.deviceData = deviceData;
        return deviceData;
    }

    public IEnumerator RegisterCoroutine(Action<RegisterResponse.RegisteredInfo> onComplete, Action<Exception> onError)
    {
        Task<RegisterResponse.RegisteredInfo> task = RegisterAsync();
        while (!task.IsCompleted) yield return null;

        if (task.Exception != null)
            onError?.Invoke(task.Exception.InnerException ?? task.Exception);
        else
        {
            Ed25519Identity identity = data.GenerateOrGetDeviceKey();
            data.SaveIdentity(task.Result.UserNumber, identity.PrivateKey);
            onComplete?.Invoke(task.Result);
        }
    }

    public async Task LoginAsync(IIUser user)
    {
        Ed25519Identity sessionKey = Ed25519Identity.Generate();
        List<byte> sessionPubKey = sessionKey.PublicKey.ToDerEncoding().ToList();

        (List<byte> userKey, ulong timestamp) prepareDelegationResp = await IIClient.PrepareDelegation(
            user.UserNumber, data.FrontendHostname, sessionPubKey, OptionalValue<ulong>.NoValue());

        var userKey = prepareDelegationResp.Item1;
        var timestamp = prepareDelegationResp.Item2;

        GetDelegationResponse getDelegationResp = await IIClient.GetDelegation(user.UserNumber, data.FrontendHostname, sessionPubKey, timestamp);

        SubjectPublicKeyInfo pubKeyInfo = new SubjectPublicKeyInfo(AlgorithmIdentifier.Ed25519(), userKey.ToArray());
        ICTimestamp expiration = new ICTimestamp(UnboundedUInt.FromUInt64(timestamp));
        byte[] signature = getDelegationResp.AsSignedDelegation().Signature.ToArray();

        EdjCase.ICP.Agent.Models.Delegation delegation = new EdjCase.ICP.Agent.Models.Delegation(pubKeyInfo, expiration);
        EdjCase.ICP.Agent.Models.SignedDelegation signedDelegation = new EdjCase.ICP.Agent.Models.SignedDelegation(delegation, signature);
        DelegationChain chain = new DelegationChain(
            pubKeyInfo,
            new List<EdjCase.ICP.Agent.Models.SignedDelegation> { signedDelegation }
        );

        // Use delegation to create DelegationIdentity
        DelegationIdentity delegateIdentity = new DelegationIdentity(data.LoadIdentity(user.UserNumber), chain);
        DelegateAgent = new HttpAgent(delegateIdentity.Identity, new Uri(data.FrontendHostname));
    }

    public IEnumerator LoginCoroutine(IIUser user, Action onComplete, Action<Exception> onError)
    {
        Task loginTask = LoginAsync(user);

        while (!loginTask.IsCompleted) yield return null;

        if (loginTask.Exception != null)
            onError?.Invoke(loginTask.Exception.InnerException ?? loginTask.Exception);
        else
            onComplete?.Invoke();
    }

    public async Task<AccountBalanceInfo> CheckICPBalanceAsync()
    {
        List<byte> accountIdentifier = AccountHelper.FromPrincipal(DelegateAgent.Identity.GetPrincipal());
        string accountHex = BitConverter.ToString(accountIdentifier.ToArray()).Replace("-", "").ToLowerInvariant();
        this.ledgerClient = new NNSLedgerApiClient(DelegateAgent, LedgerCanisterPrincipal, new CandidConverter());

        // Debug.Log("Principal: " + ledgerClient.Agent.Identity);
        // Debug.Log("Your Account Identifier (hex): " + accountHex);

        var accountBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(accountIdentifier));
        ulong icpBalance = accountBalance.E8s / 100_000_000;
        // Console.WriteLine($"Updated Balance: {icpBalance} ICP");

        return new AccountBalanceInfo(accountIdentifier, accountHex, icpBalance);  
    }

    public IEnumerator ICPBalanceCoroutine(Action<AccountBalanceInfo> onComplete, Action<Exception> onError)
    {
        Task<AccountBalanceInfo> balanceCheck = CheckICPBalanceAsync();
        while (!balanceCheck.IsCompleted) yield return null;

        if (balanceCheck.Exception != null)
            onError?.Invoke(balanceCheck.Exception.InnerException ?? balanceCheck.Exception);
        else
            onComplete?.Invoke(balanceCheck.Result);
    }
}

public class AccountBalanceInfo
{
    public List<byte> AccountID { get; private set; }
    public string AccountIDHex { get; private set; }
    public ulong ICPBalance { get; private set; }

    public AccountBalanceInfo(List<byte> accountID, string accountIdHex, ulong icpBalance)
    {
        AccountID = accountID;
        AccountIDHex = accountIdHex;
        ICPBalance = icpBalance;
    }
}

public class IIUser
{
    public ulong UserNumber { get; private set; }

    public IIUser(ulong userNumber)
    {
        UserNumber = userNumber;
    }
}
