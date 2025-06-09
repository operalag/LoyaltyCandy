using EdjCase.ICP.Agent.Identities;
using EdjCase.ICP.Agent;
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using EdjCase.ICP.Agent.Models;
using LoyaltyCandy.InternetIdentity;
using LoyaltyCandy.InternetIdentity.Models;

class SetupData
{
    private Ed25519Identity identity;
    public string FrontendHostname { get { return "http://localhost:8080"; } set { } }

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
        string directory = "identityData"; // Subfolder name
        Directory.CreateDirectory(directory); // Create if it doesn't exist
        string path = Path.Combine(directory, $"{userNumber}_identity.key");
    
    
        string base64Key = Convert.ToBase64String(privateKeyBytes);
        File.WriteAllText(path, base64Key);
    }

    internal Ed25519Identity LoadIdentity(ulong userNumber)
    {
        string directory = "identityData"; // Subfolder name
        string path = Path.Combine(directory, $"{userNumber}_identity.key");
        

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
    public Principal CanisterPrincipal { get; private set; }
    public InternetIdentityApiClient IIClient { get; set; }
    public string hostAddress { get; private set; }

    internal SetupData data = new SetupData(); //was private
    private HttpAgent Agent { get; set; }
    internal DeviceData deviceData;

    public IIClientWrapper(string iiCanisterId = "qhbym-qaaaa-aaaaa-aaafq-cai")
    {
        this.CanisterPrincipal = Principal.FromText(iiCanisterId);
        this.hostAddress = data.FrontendHostname;

        // Temporary agent for registration
        Ed25519Identity tempIdentity = data.GenerateOrGetDeviceKey();
        ByteArrayToStringConversion idkey = new ByteArrayToStringConversion(tempIdentity.GetPublicKey().PublicKey);
        // Console.WriteLine("TempKey: " + idkey.ToString());
        this.Agent = new HttpAgent(tempIdentity, new Uri(this.hostAddress));
        this.IIClient = new InternetIdentityApiClient(Agent, CanisterPrincipal, new CandidConverter());
    }

    public void SetupAgentWithIdentity(Ed25519Identity identity)
    {
        this.Agent = new HttpAgent(identity, new Uri(this.hostAddress));
        this.IIClient = new InternetIdentityApiClient(this.Agent, this.CanisterPrincipal, new CandidConverter());
    }

    private async Task<RegisterResponse.RegisteredInfo> RegisterAsync()
    {
        Challenge challenge = await IIClient.CreateChallenge();
        Console.WriteLine("Challenge Key: " + challenge.ChallengeKey);

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
        DeviceData dD = new DeviceData
        {
            Pubkey = data.GenerateOrGetDeviceKey().PublicKey.ToDerEncoding().ToList(),
            Alias = $"My Device {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
            CredentialId = null,
            Purpose = Purpose.Authentication,
            KeyType = KeyType.SeedPhrase,
            Protection = DeviceProtection.Unprotected
        };

        deviceData = dD;
        return dD;
    }

    public IIUser Register()
    {
        RegisterResponse.RegisteredInfo result = RegisterAsync().Result;

        ulong userNumber = result.UserNumber;

        // Save identity to disk using user number
        Ed25519Identity identity = data.GenerateOrGetDeviceKey();
        ByteArrayToStringConversion idkey = new ByteArrayToStringConversion(identity.GetPublicKey().PublicKey);
        // Console.WriteLine("idKey: " + idkey.ToString());
        data.SaveIdentity(userNumber, identity.PrivateKey);
        return new IIUser(userNumber);
    }

    public void Login(IIUser user)
    {
        Ed25519Identity sessionKey = Ed25519Identity.Generate();
        List<byte> sessionPubKey = sessionKey.PublicKey.ToDerEncoding().ToList();

        (List<byte> ReturnArg0, ulong ReturnArg1) prep = IIClient.PrepareDelegation(user.UserNumber, data.FrontendHostname, sessionPubKey, OptionalValue<ulong>.NoValue()).Result;
        GetDelegationResponse delegationResponse = IIClient.GetDelegation(user.UserNumber, data.FrontendHostname, sessionPubKey, prep.ReturnArg1).Result;

        SubjectPublicKeyInfo pubKeyInfo = new SubjectPublicKeyInfo(AlgorithmIdentifier.Ed25519(), prep.ReturnArg0.ToArray());
        ICTimestamp expiration = new ICTimestamp(UnboundedUInt.FromUInt64(prep.ReturnArg1));
       
        byte[] signature = delegationResponse.AsSignedDelegation().Signature.ToArray();
        EdjCase.ICP.Agent.Models.Delegation delegation = new EdjCase.ICP.Agent.Models.Delegation(pubKeyInfo, expiration);
        EdjCase.ICP.Agent.Models.SignedDelegation signedDelegation = new EdjCase.ICP.Agent.Models.SignedDelegation(delegation, signature);

        DelegationChain chain = new DelegationChain(
            pubKeyInfo,
            new List<EdjCase.ICP.Agent.Models.SignedDelegation> { signedDelegation }
        );
        Ed25519Identity identity = data.LoadIdentity(user.UserNumber);
        DelegationIdentity delegatedIdentity = new DelegationIdentity(identity, chain);
        DelegateAgent = new HttpAgent(delegatedIdentity.Identity, new Uri(data.FrontendHostname));
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