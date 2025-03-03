This repository contains the components for Loyalty Candy. A game where state, scoring and transactions are backend by the ICP ecosystem.

The main folder contains the Unity 3D engine project with the game code and assets.

In the subfolder ICP-components are:
* the code for the canisters that run on the ICP as a backend to the game.
* the code for a C# test client to verify the bridge between the canister and the C#.NET runtime

To run this repo you need to setup:
* a .NET runtime and SDK compatible with Unity
* Unity Editor 2022.3.39f1
* deploy the canister locally according to the SDK 
