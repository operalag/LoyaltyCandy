using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using EdjCase.ICP.Agent.Identities;
using LoyaltyCandy.NNSDapp;

IIClientWrapper iiClient = new IIClientWrapper();

// IIUser user = iiClient.Register();
IIUser user = new IIUser(10001L);

// iiClient.Login(user);
// var wrapper2 = new IIClientWrapper(); // Will re-generate new temp key for delegation

Ed25519Identity identity = iiClient.data.LoadIdentity(user.UserNumber);
iiClient.SetupAgentWithIdentity(identity); // Use original registered key
iiClient.Login(user);

Principal userPrincipalID = iiClient.IIClient.GetPrincipal(user.UserNumber, iiClient.hostAddress).Result;

Console.WriteLine($"User {user.UserNumber} registered");
Console.WriteLine($"User Principal ID: {userPrincipalID}");

ByteArrayToStringConversion delegateIdentityPubkey = new ByteArrayToStringConversion(iiClient.DelegateAgent.Identity.GetPublicKey().PublicKey);
Console.WriteLine($"User Delegate Identity: {delegateIdentityPubkey.ToString()}");

List<byte> userAccountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());

string accountHex = BitConverter.ToString(userAccountIdentifier.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine("User Account Identifier (hex): " + accountHex);

// ByteListToStringConversion iipubkey = new ByteListToStringConversion(iiClient.deviceData.Pubkey);
// Console.WriteLine($"User Device Pubkey: {iipubkey.GetString()}");
// Console.WriteLine($"User Alias: {iiClient.deviceData.Alias}");
// Console.WriteLine($"User CredentialId: {iiClient.deviceData.CredentialId}");
// Console.WriteLine($"User Origin: {iiClient.deviceData.Origin}");
// Console.WriteLine($"User Metadata: {iiClient.deviceData.Metadata}");

// Uri network = new Uri("http://localhost:8080");
// var agent = new HttpAgent(null, network);

// Tester tester = new Tester(climateClient);
// await tester.UpdateCurrentRank();
// await tester.printRanking(10, 10);

// await tester.SetScoreAsync(323);
// await tester.printRanking(1, 1);

// Step 8: Use delegated identity to call NNS canisters
Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);

var updatedBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(userAccountIdentifier));
Console.WriteLine($"User Updated Balance: {updatedBalance.E8s / 100_000_000} ICP");

//login to custom canister
Principal climateWalletPrincipal = Principal.FromText("uxrrr-q7777-77774-qaaaq-cai");
ClimateWalletApiClient climateClient = new ClimateWalletApiClient(iiClient.DelegateAgent, climateWalletPrincipal);

// var result = await climateClient.ReadGameData();  // Get current user's data
// var data = result.Item1;
// var principalText = result.Item2;
// Console.WriteLine($"Fetched data for principal {principalText} - IsMale: {data.GetValueOrThrow().IsMale}, Gem: {data.GetValueOrThrow().Gem}");

// await climateClient.WriteGameData(false, 5055f); // Save data for current user
// Console.WriteLine($"Game data saved for principal: {savedPrincipal}");

// Custom canister account
// List<byte> climateSubAccount = AccountHelper.FromPrincipal(climateWalletPrincipal); // the one with 2000 ICP
Account climateAccount = new Account
{
    Owner      = climateWalletPrincipal,
    Subaccount = null                   // implicit OptionalValue wrap
};

List<byte> climateAccountIdBytes = await ledgerClient.AccountIdentifier(climateAccount);
string climateAccountIdHex = BitConverter.ToString(climateAccountIdBytes.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine($"Climate Account‑ID hex: {climateAccountIdHex}");
var balTxt = climateClient.GetMyBalanceTxt();
Console.WriteLine($"Climate Balance: {balTxt.Result}");


Principal receiver = Principal.FromText("jfusi-qgype-2zc3m-5h7ah-bz4f3-er4g5-koznh-57cic-a7hkp-ntylt-dqe");

// var BlockIndex = await climateClient.SendIcp(receiver, 100_000_000_0); //sending token for canister

// List<byte> receiverSubAccount = AccountHelper.FromPrincipal(receiver); // the one with 2000 ICP
// Account.SubaccountInfo richSubAcc = new Account.SubaccountInfo(receiverSubAccount);

Account receiverAccount = new Account
{
    Owner      = receiver,
    Subaccount = null                    // implicit OptionalValue wrap
};

List<byte> receiverAccountIdBytes = await ledgerClient.AccountIdentifier(receiverAccount);
string receiverAccountIdHex = BitConverter.ToString(receiverAccountIdBytes.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine($"Receiver Account‑ID hex: {receiverAccountIdHex}");
Tokens receiverBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(receiverAccountIdBytes));
Console.WriteLine($"Receiver Balance: {receiverBalance.E8s / 100_000_000} ICP");

