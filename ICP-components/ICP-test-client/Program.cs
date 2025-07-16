using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using EdjCase.ICP.Agent.Identities;

IIClientWrapper iiClient = new IIClientWrapper();

IIUser user = iiClient.Register();
// IIUser user = new IIUser(10003L);

Ed25519Identity identity = iiClient.data.LoadIdentity(user.UserNumber);
iiClient.SetupAgentWithIdentity(identity); // Use original registered key
iiClient.Login(user);

Principal userPrincipalID = iiClient.DelegateAgent.Identity.GetPrincipal();
Console.WriteLine($"User {user.UserNumber} registered");
Console.WriteLine($"User Principal ID: {userPrincipalID}");

// Step 8: Use delegated identity to call NNS canisters
Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);


//login to custom canister
Principal climateWalletPrincipal = Principal.FromText("uxrrr-q7777-77774-qaaaq-cai");
ClimateWalletApiClient climateClient = new ClimateWalletApiClient(iiClient.DelegateAgent, climateWalletPrincipal);

//Sender Account
Account climateAccount = new Account
{
    Owner      = climateWalletPrincipal,
    Subaccount = null                   // implicit OptionalValue wrap
};

List<byte> climateAccountIdBytes = await ledgerClient.AccountIdentifier(climateAccount);
string climateAccountIdHex = BitConverter.ToString(climateAccountIdBytes.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine($"Climate Account‑ID hex: {climateAccountIdHex}");

var balTxt = climateClient.GetMyCanisterBalanceTxt();
Console.WriteLine($"Climate Balance: {balTxt.Result}");

//Rceiver Account
Account receiverAccount = new Account
{
    Owner      = userPrincipalID,
    Subaccount = null                    // implicit OptionalValue wrap
};

List<byte> receiverAccountIdBytes = await ledgerClient.AccountIdentifier(receiverAccount);
string receiverAccountIdHex = BitConverter.ToString(receiverAccountIdBytes.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine($"Receiver Account‑ID hex: {receiverAccountIdHex}");
Tokens receiverBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(receiverAccountIdBytes));
Console.WriteLine($"Receiver Balance: {receiverBalance.E8s / 100_000_000} ICP");

var val = climateClient.RegisterPlayer("Player5", true); // Add player to the game
var score = climateClient.UpdatePlayerScore(3123); //update Score
var readResult = await climateClient.GetGameData();  // Get current user's data
Console.WriteLine($" Name: {readResult.Name}, IsMale: {readResult.IsMale}, Rank: {readResult.Rank}, Score: {readResult.Score},");
Console.WriteLine($"user Account Address hex: {readResult.PlayerAddress}");

Tester tester = new Tester(climateClient);
await tester.UpdateCurrentRank();
await tester.printRanking(10, 10);

// var top10 = climateClient.RewardTop10(100_000_000_0); // Reward top 10 players with 1 ICP each