using EdjCase.ICP.Agent.Agents;
// using EdjCase.ICP.Agent.Models;
using EdjCase.ICP.Agent.Identities;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using System.Security.Cryptography;
using LoyaltyCandy.NNSGovernance.Models;

IIClientWrapper iiClient = new IIClientWrapper();


// read user id from command line
// if no user then register
// IIUser user = iiClient.Register();
// Console.WriteLine($"User {user.UserNumber} registered");

IIUser user = new IIUser(10001L);
Console.WriteLine($"Login in User {user.UserNumber}");
iiClient.Login(user);



// // Step 8: Use delegated identity to call NNS canisters
Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);
Console.WriteLine("Ledger Client canister: " + ledgerClient.CanisterId);

List<byte> accountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());
AccountBalanceArgs balanceRequest = new AccountBalanceArgs(accountIdentifier);

var balance = await ledgerClient.AccountBalance(balanceRequest);
Console.WriteLine("Balance: " + balance.E8s + " e8s");
