using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using SubAccount = System.Collections.Generic.List<System.Byte>;
using System.Security.Cryptography;
using Icrc1Tokens = EdjCase.ICP.Candid.Models.UnboundedUInt;
using System.Numerics;
using EdjCase.ICP.Agent.Identities;

IIClientWrapper iiClient = new IIClientWrapper();

// IIUser user = iiClient.Register();
// iiClient.Login(user);

// var wrapper2 = new IIClientWrapper(); // Will re-generate new temp key for delegation
IIUser user = new IIUser(10000L);
Ed25519Identity identity = iiClient.data.LoadIdentity(user.UserNumber);
iiClient.SetupAgentWithIdentity(identity); // Use original registered key
iiClient.Login(user); 

Console.WriteLine($"User {user.UserNumber} registered");
Console.WriteLine($"User Principal ID: {iiClient.IIClient.GetPrincipal(user.UserNumber, iiClient.hostAddress).Result}");

ByteArrayToStringConversion delegateIdentityPubkey = new ByteArrayToStringConversion(iiClient.DelegateAgent.Identity.GetPublicKey().PublicKey);
Console.WriteLine($"User Delegate Identity: {delegateIdentityPubkey.ToString()}");

// ByteListToStringConversion iipubkey = new ByteListToStringConversion(iiClient.deviceData.Pubkey);
// Console.WriteLine($"User Device Pubkey: {iipubkey.GetString()}");
// Console.WriteLine($"User Alias: {iiClient.deviceData.Alias}");
// Console.WriteLine($"User CredentialId: {iiClient.deviceData.CredentialId}");
// Console.WriteLine($"User Origin: {iiClient.deviceData.Origin}");
// Console.WriteLine($"User Metadata: {iiClient.deviceData.Metadata}");

// Uri network = new Uri("http://localhost:8080");
// var agent = new HttpAgent(null, network);

//login to custome canister
Principal climateWalletPrincipal = Principal.FromText("uxrrr-q7777-77774-qaaaq-cai");
ClimateWalletApiClient climateClient = new ClimateWalletApiClient(iiClient.DelegateAgent, climateWalletPrincipal);

// Tester tester = new Tester(climateClient);
// await tester.UpdateCurrentRank();
// await tester.printRanking(10, 10);

// await tester.SetScoreAsync(323);
// await tester.printRanking(1, 1);


 
// string savedPrincipal = await climateClient.WriteGameData(false, 5055f); // Save data for current user
// Console.WriteLine($"Game data saved for principal: {savedPrincipal}");

var result = await climateClient.ReadGameData();  // Get current user's data
var data = result.Item1;
var principalText = result.Item2;

Console.WriteLine($"Fetched data for principal {principalText} - IsMale: {data.GetValueOrThrow().IsMale}, Gem: {data.GetValueOrThrow().Gem}");


// Step 8: Use delegated identity to call NNS canisters
// Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
// NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);

List<byte> accountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());
string accountHex = BitConverter.ToString(accountIdentifier.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine("User Account Identifier (hex): " + accountHex);

// var updatedBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(accountIdentifier));
// Console.WriteLine($"User Updated Balance: {updatedBalance.E8s / 100_000_000} ICP");

//10000
//PID: kj5lj-d3fmc-ckhts-dmz6i-3xi65-fp34o-xukmb-jqqpd-tc7qi-rpqrs-wqe
//SaveID: bvvok-g7bh2-4p4ll-scuhm-phqju-twf57-lvsq4-ykki6-wxdrg-fjwov-uae
//delegate identity: 15368010 

//10001
//PID: u2jjh-kxhlg-smjzm-jm7gr-df6y7-twjqi-7fi2y-f77zt-gp7x6-2nfch-wae
//SaveID: bvvok-g7bh2-4p4ll-scuhm-phqju-twf57-lvsq4-ykki6-wxdrg-fjwov-uae
// /delegate identity: 15368010 