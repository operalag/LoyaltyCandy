// See https://aka.ms/new-console-template for more information
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;
using LoyaltyCandy.HelloClient;

Console.WriteLine("Hello, World!");
Uri network = new Uri("http://localhost:4943");
var agent = new HttpAgent(null, network);

// Principal canisterId = Principal.FromText("bkyz2-fmaaa-aaaaa-qaaaq-cai");
// var helloClient = new HelloClientApiClient(agent, canisterId);
// string greeting = await helloClient.Greet("Casper");

// Console.WriteLine(greeting);


Principal canisterId2 = Principal.FromText("aovwi-4maaa-aaaaa-qaagq-cai");
ClimateWalletApiClient climateClient = new ClimateWalletApiClient(agent, canisterId2);

// UnboundedUInt counterValue = await climateClient.Read();
// Console.WriteLine(counterValue.ToString());

// await climateClient.Inc();
// counterValue = await climateClient.Read();
// Console.WriteLine(counterValue.ToString());

// counterValue = await climateClient.Bump();
// Console.WriteLine(counterValue.ToString());


// counterValue = await climateClient.Set((uint) 345);
// Console.WriteLine(counterValue.ToString());

Tester tester = new Tester(climateClient);
await tester.UpdateCurrentRank();
await tester.printRanking(10, 10);

await tester.SetScoreAsync(231);
await tester.printRanking(1, 1);

await tester.SetScoreAsync(234);
await tester.printRanking(1, 1);

await tester.SetScoreAsync(323);
await tester.printRanking(1, 1);

await tester.SetScoreAsync(3);
await tester.printRanking(1, 1);
