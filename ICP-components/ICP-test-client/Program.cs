using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.NNSLedger;
using LoyaltyCandy.NNSLedger.Models;
using SubAccount = System.Collections.Generic.List<System.Byte>;
using System.Security.Cryptography;
using Icrc1Tokens = EdjCase.ICP.Candid.Models.UnboundedUInt;
using System.Numerics;

IIClientWrapper iiClient = new IIClientWrapper();
// IIUser user = iiClient.Register();
// Console.WriteLine($"User {user.UserNumber} registered");

IIUser user = new IIUser(10001L);
Console.WriteLine($"Login in User {user.UserNumber}");
iiClient.Login(user);


// // Step 8: Use delegated identity to call NNS canisters
Principal ledgerCanisterId = Principal.FromText("ryjl3-tyaaa-aaaaa-aaaba-cai");
// Principal ledgerCanisterId = Principal.FromText("vg3po-ix777-77774-qaafa-cai");
NNSLedgerApiClient ledgerClient = new NNSLedgerApiClient(iiClient.DelegateAgent, ledgerCanisterId);
Console.WriteLine("Ledger Client canister: " + ledgerClient.CanisterId);


List<byte> accountIdentifier = AccountHelper.FromPrincipal(iiClient.DelegateAgent.Identity.GetPrincipal());
string accountHex = BitConverter.ToString(accountIdentifier.ToArray()).Replace("-", "").ToLowerInvariant();
Console.WriteLine("Your Account Identifier (hex): " + accountHex);
var updatedBalance = await ledgerClient.AccountBalance(new AccountBalanceArgs(accountIdentifier));
Console.WriteLine($"Updated Balance: {updatedBalance.E8s / 100_000_000} ICP");

