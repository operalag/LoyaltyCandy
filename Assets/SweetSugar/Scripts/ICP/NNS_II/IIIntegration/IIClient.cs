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


class SetupData
{
    private Ed25519Identity identity;
    internal string networkUrl;

    internal Ed25519Identity GenerateOrGetDeviceKey()
    {
        if (identity == null)
        {
            identity = Ed25519Identity.Generate();
        }
        return identity;
    }
    
    internal void SaveIdentity(ulong userNumber, byte[] privateKeyBytes)
    {
        string path = Path.Combine(Application.persistentDataPath, $"{userNumber}_identity.key");

        string base64Key = Convert.ToBase64String(privateKeyBytes);
        File.WriteAllText(path, base64Key);
    }

    internal Ed25519Identity LoadIdentity(ulong userNumber)
    {
        string path = Path.Combine(Application.persistentDataPath, $"{userNumber}_identity.key");
        
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Identity file not found for user {userNumber}");
        }

        string base64Key = File.ReadAllText(path);
        byte[] privateKeyBytes = Convert.FromBase64String(base64Key);
        return Ed25519Identity.FromPrivateKey(privateKeyBytes);
    }
}

public class IIClientWrapper
{
    public HttpAgent DelegateAgent { get; private set; }
    public Principal IICanisterPrincipal { get; private set; }
    public Principal LedgerCanisterPrincipal { get; private set; }

    public InternetIdentityApiClient IIClient { get; set; }
    public NNSLedgerApiClient ledgerClient { get; set; }



    internal SetupData data = new SetupData();
    private HttpAgent Agent { get; set; }

    public IIClientWrapper(string networkUrl, string iiCanisterId, string ledgerCanisterId)
    {
        this.IICanisterPrincipal = Principal.FromText(iiCanisterId);
        this.LedgerCanisterPrincipal = Principal.FromText(ledgerCanisterId);
        data.networkUrl = networkUrl;

        // Temporary agent for registration
        Ed25519Identity tempIdentity = data.GenerateOrGetDeviceKey();
        this.Agent = new HttpAgent(tempIdentity, new Uri(data.networkUrl));
        this.IIClient = new InternetIdentityApiClient(Agent, IICanisterPrincipal, new CandidConverter());
    }

    public void SetupAgentWithIdentity(Ed25519Identity identity)
    {
        this.Agent = new HttpAgent(identity, new Uri(data.networkUrl));
        this.IIClient = new InternetIdentityApiClient(this.Agent, this.IICanisterPrincipal, new CandidConverter());
    }

    private async Task<RegisterResponse.RegisteredInfo> RegisterAsync()
    {
        Challenge challenge = await IIClient.CreateChallenge();
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
            user.UserNumber, data.networkUrl, sessionPubKey, OptionalValue<ulong>.NoValue());

        var userKey = prepareDelegationResp.Item1;
        var timestamp = prepareDelegationResp.Item2;

        GetDelegationResponse getDelegationResp = await IIClient.GetDelegation(user.UserNumber, data.networkUrl, sessionPubKey, timestamp);

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
        Debug.Log("Setting up agent " + data.networkUrl);
        DelegateAgent = new HttpAgent(delegateIdentity.Identity, new Uri(data.networkUrl));
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

        var accountBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(accountIdentifier));
        ulong icpBalance = accountBalance.E8s / 100_000_000;
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
