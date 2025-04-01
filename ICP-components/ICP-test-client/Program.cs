// See https://aka.ms/new-console-template for more information
using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.HelloClient;

Console.WriteLine("Hello, World!");
Uri network = new Uri("http://localhost:4943");
var agent = new HttpAgent(null, network);

// Principal canisterId = Principal.FromText("bkyz2-fmaaa-aaaaa-qaaaq-cai");
// var helloClient = new HelloClientApiClient(agent, canisterId);
// string greeting = await helloClient.Greet("Casper");

// Console.WriteLine(greeting);


Principal canisterId2 = Principal.FromText("bkyz2-fmaaa-aaaaa-qaaaq-cai");
ClimateWalletApiClient climateClient = new ClimateWalletApiClient(agent, canisterId2);

UnboundedUInt counterValue = await climateClient.Read();
Console.WriteLine(counterValue.ToString());

await climateClient.Inc();
counterValue = await climateClient.Read();
Console.WriteLine(counterValue.ToString());

counterValue = await climateClient.Bump();
Console.WriteLine(counterValue.ToString());


counterValue = await climateClient.Set((uint) 345);
Console.WriteLine(counterValue.ToString());