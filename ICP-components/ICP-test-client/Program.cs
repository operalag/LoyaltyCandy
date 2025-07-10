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

Principal NNS_DAPP = Principal.FromText("qsgjb-riaaa-aaaaa-aaaga-cai");
NNSDappApiClient dapp = new NNSDappApiClient(iiClient.DelegateAgent, NNS_DAPP);

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

// Tokens climateBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(climateAccountIdBytes));
// Console.WriteLine($"Climate Balance: {climateBalance.E8s / 100_000_000.0} ICP");

var balTxt = climateClient.GetMyBalanceTxt();
Console.WriteLine($"Climate Balance: {balTxt.Result}");

// Principal richPrincipalId = Principal.FromText("dmvep-nicpy-ys25g-nqpqp-5szde-bwdop-a4bzm-cisrh-7us4z-u67eo-hqe");
// List<byte> subAccount = AccountHelper.FromPrincipal(richPrincipalId); // the one with 2000 ICP
// Account.SubaccountInfo richSubAcc = new Account.SubaccountInfo(subAccount);

// Account richAccount = new Account
// {
//     Owner      = richPrincipalId,
//     Subaccount = richSubAcc                    // implicit OptionalValue wrap
// };

// List<byte> richAccountIdBytes = await ledgerClient.AccountIdentifier(richAccount);
// string richAccountIdHex = BitConverter.ToString(richAccountIdBytes.ToArray()).Replace("-", "").ToLowerInvariant();
// Console.WriteLine($"Rich Account‑ID hex: {richAccountIdHex}");
// Tokens richbalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(richAccountIdBytes));
// Console.WriteLine($"Balance: {richbalance.E8s / 100_000_000.0} ICP");

// Principal recipientPrincipal = Principal.FromText("3fh5t-iysez-llvtg-r4s3w-hbjd2-acamn-tzbxi-clgwr-nosb3-unxy6-5ae");
// List<byte> receiptAccountId = AccountHelper.FromPrincipal(recipientPrincipal); //recipient account‑identifier
// Account.SubaccountInfo receiptSubAcc = new Account.SubaccountInfo(receiptAccountId);

// Account receiptAccount = new Account
// {
//     Owner = recipientPrincipal,
//     Subaccount = receiptSubAcc              // implicit OptionalValue wrap
// };

// List<byte> receiptAccountIdByte = await ledgerClient.AccountIdentifier(receiptAccount);
// string receiptAccountIdHex = BitConverter.ToString(receiptAccountIdByte.ToArray()).Replace("-", "").ToLowerInvariant();
// Console.WriteLine("Receipt User Account Identifier (hex): " + receiptAccountIdHex);
// Tokens receiptBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(receiptAccountIdByte));
// Console.WriteLine($"Balance: {receiptBalance.E8s / 100_000_000.0} ICP");

// TransferArgs tx = new TransferArgs
// {
//     Fee = new Tokens { E8s = 10_000UL },
//     Amount = new Tokens { E8s = 500_000_000UL },   // 5 ICP
//     FromSubaccount = new TransferArgs.FromSubaccountInfo(richAccountIdBytes), // same 32 bytes
//     To = receiptAccountIdByte
// };

// var result = await ledgerClient.Transfer(tx);
// switch (result.Tag) //reesult
// {
//     case TransferResultTag.Ok:
//         // Console.WriteLine($"Transfer included in block {result.Value}");
//         ulong block = result.AsOk();
//         Console.WriteLine($"Included in block {block}");
//         break;

//     case TransferResultTag.Err:
//         // Console.WriteLine($" Transfer failed: {result.Value}"); // Tag = InsufficientFunds etc.
//         TransferError err = result.AsErr();
//         Console.WriteLine($"Failed: {err.Tag}");
//         break;
// }

// var balance = await ledgerClient.AccountBalance(
//     new AccountBalanceArgs(AccountHelper.FromPrincipal(
//         userPrincipalID)));

// Console.WriteLine($"Sub‑account balance: {balance.E8s/100_000_000.0} ICP");


// List<byte> defaultId = AccountHelper.FromPrincipal(userPrincipalID); // default sub

// var bal = await ledgerClient.AccountBalance(new AccountBalanceArgs(defaultId));
// Console.WriteLine($"Default sub balance: {bal.E8s / 100_000_000.0} ICP");

// var updatedBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(userAccountIdentifier));
// Console.WriteLine($"User Updated Balance: {updatedBalance.E8s / 100_000_000} ICP");