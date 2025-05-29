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

class SetupData
{
    public Ed25519Identity SessionKey { get; set; }

    public DeviceData DeviceData
    {
        get
        {
            return GenerateOrGetDD(GenerateOrGetDeviceKey().PublicKey.ToDerEncoding());
        }

        private set { }
    }

    private DeviceData GenerateOrGetDD(byte[] pubKey)
    {
        if (deviceData == null)
        {
            deviceData = new DeviceData
            {
                Alias = "MyDevice",
                Pubkey = pubKey.ToList<byte>(),
                KeyType = KeyType.SeedPhrase, // Optional
                Purpose = Purpose.Authentication,
                CredentialId = null,
                Protection = DeviceProtection.Unprotected
            };
        }

        return deviceData;
    }

    private Ed25519Identity GenerateOrGetDeviceKey()
    {
        if (identity == null)
        {
            // try load from disk if not then generate
            identity = Ed25519Identity.Generate();
            // Save to disk;
        }
        return identity;
    }

    private Ed25519Identity identity;
    private DeviceData deviceData;
    public string FrontendHostname { get { return "http://localhost:8080"; } set { } }


    internal Ed25519Identity LoadIdentity()
    {
        if (identity == null && File.Exists("identity.key"))
        {
            // Read the base64-encoded key from file
            string base64Key = File.ReadAllText("identity.key");

            // Convert it back to bytes
            byte[] privateKeyBytes = Convert.FromBase64String(base64Key);

            // Re-create identity
            identity = Ed25519Identity.FromPrivateKey(privateKeyBytes);
        }
        else if (identity == null)
        {
            identity = GenerateOrGetDeviceKey();
            // Get raw private key bytes (usually 32 bytes)
            byte[] privateKeyBytes = identity.PrivateKey;

            // Convert to base64 or hex for saving (here we use base64)
            string base64Key = Convert.ToBase64String(privateKeyBytes);

            // Save to file
            File.WriteAllText("identity.key", base64Key);
        }

        return identity;
    } 

}

public class IIClientWrapper
{
    public HttpAgent DelegateAgent { get; private set; }
    public Principal CanisterPrincipal { get; private set; }
    public InternetIdentityApiClient IIClient { get; set; }

    private SetupData data = new SetupData();
    private HttpAgent Agent { get; set; }

    public IIClientWrapper(string iiCanisterId = "qhbym-qaaaa-aaaaa-aaafq-cai")
    {
        this.CanisterPrincipal = Principal.FromText(iiCanisterId);
        this.Agent = SetupAgent(data.FrontendHostname);
        this.IIClient = new InternetIdentityApiClient(Agent, CanisterPrincipal, new CandidConverter());
    }

    public HttpAgent SetupAgent(string hostAddress)
    {
        // this.SessionKey = Ed25519Identity.Generate(); // Or load from existing PEM
        // this.PubKey = [.. SessionKey.GetPublicKey().ToDerEncoding()];
        return new HttpAgent(data.LoadIdentity(), new Uri(hostAddress));
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
        RegisterResponse response = await IIClient.Register(data.DeviceData, captchaResult, OptionalValue<Principal>.NoValue());

        return response.AsRegistered();
    }

    public IIUser Register()
    {
        Task<RegisterResponse.RegisteredInfo> task = RegisterAsync();

        task.Wait();

        return new IIUser(task.Result.UserNumber);
    }

    public void Login(IIUser user)
    {
        Ed25519Identity sessionKey = Ed25519Identity.Generate();
        List<byte> pubKey = sessionKey.PublicKey.ToDerEncoding().ToList<byte>();
        Task<(List<byte> userKey, ulong timestamp)> task = IIClient.PrepareDelegation(user.UserNumber, data.FrontendHostname, pubKey, OptionalValue<ulong>.NoValue());

        task.Wait();

        Task<GetDelegationResponse> task2 = IIClient.GetDelegation(user.UserNumber, data.FrontendHostname, pubKey, task.Result.timestamp);

        task2.Wait();

        SubjectPublicKeyInfo pubKeyInfo = new SubjectPublicKeyInfo(AlgorithmIdentifier.Ed25519(), task.Result.userKey.ToArray());
        ICTimestamp expiration = new ICTimestamp(UnboundedUInt.FromUInt64(task.Result.timestamp));
        byte[] signature = task2.Result.AsSignedDelegation().Signature.ToArray();

        EdjCase.ICP.Agent.Models.Delegation delegation = new EdjCase.ICP.Agent.Models.Delegation(pubKeyInfo, expiration);
        EdjCase.ICP.Agent.Models.SignedDelegation signedDelegation = new EdjCase.ICP.Agent.Models.SignedDelegation(delegation, signature);

        DelegationChain chain = new DelegationChain(
            pubKeyInfo,
            new List<EdjCase.ICP.Agent.Models.SignedDelegation> { signedDelegation }
        );

        // Use delegation to create DelegationIdentity
        DelegationIdentity delegateIdentity = new DelegationIdentity(data.LoadIdentity(), chain);
        DelegateAgent = new HttpAgent(delegateIdentity.Identity, new Uri(data.FrontendHostname));
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
