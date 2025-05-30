using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using SubAccount = System.Collections.Generic.List<System.Byte>;

Console.WriteLine("Hello, World!");
Uri network = new Uri("http://192.168.8.72:4943");
var agent = new HttpAgent(null, network);

Principal canisterId2 = Principal.FromText("asrmz-lmaaa-aaaaa-qaaeq-cai");
ClimateWalletApiClient climateClient = new ClimateWalletApiClient(agent, canisterId2);

// read user id from command line
// if no user then register
IIUser user = iiClient.Register();
// Console.WriteLine($"User {user.UserNumber} registered");

// IIUser user = new IIUser(10001L);
Console.WriteLine($"Login in User {user.UserNumber}");
iiClient.Login(user);



// // Step 8: Use delegated identity to call NNS canisters
Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);
Console.WriteLine("Ledger Client canister: " + ledgerClient.CanisterId);

List<byte> accountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());

string accountHex = BitConverter.ToString(accountIdentifier.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine("Your Account Identifier (hex): " + accountHex);

// AccountBalanceArgs balanceRequest = new AccountBalanceArgs(accountIdentifier);

// var initialBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(accountIdentifier));
// Console.WriteLine($"Initial Balance: {initialBalance.E8s / 100_000_000} ICP");

// // Transfer ICP (0.5 ICP)
// try 
// {
//     var transferArgs = new TransferArgs 
//     {
//         To = accountIdentifier,
//         Amount = new Tokens { E8s = 50_000_000 },
//         Fee = new Tokens { E8s = 10_000 },
//         Memo = 0,
//         FromSubaccount = null // Main account
//     };
    
//     await ledgerClient.Transfer(transferArgs);
//     Console.WriteLine("Transfer successful!");
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Transfer failed: {ex.Message}");
// }

// // Check updated balance
// var updatedBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(accountIdentifier));
// Console.WriteLine($"Updated Balance: {updatedBalance.E8s / 100_000_000} ICP");



// var mintArgs = new MintArgs
// {
//     To = AccountHelper.FromPrincipal(ledgerCanisterId),
//     Amount = new Tokens { E8s = 1_000_000_000 } // 10 ICP
// };

// NNSLedgerMintSetup nNSLedgerMintSetup = new NNSLedgerMintSetup(iiClient.DelegateAgent, ledgerCanisterId);

// var result = await nNSLedgerMintSetup.Mint(mintArgs);

// Console.WriteLine("Mint result: " + result);



// var balance = await ledgerClient.AccountBalance(balanceRequest);
// Console.WriteLine("Balance: " + balance.E8s + " e8s");
