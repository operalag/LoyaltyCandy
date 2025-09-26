using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Agent.Agents;
using LoyaltyCandy.NNSLedger.Models;


public class MintArgs
{
    [CandidName("to")]
    public List<byte> To { get; set; }

    [CandidName("amount")]
    public Tokens Amount { get; set; }
}

public class NNSLedgerMintSetup
{
    private readonly IAgent _agent;
    public Principal CanisterId { get; }

    public NNSLedgerMintSetup(IAgent agent, Principal canisterId)
    {
        _agent = agent;
        CanisterId = canisterId;
    }

    public async Task<ulong> Mint(MintArgs args)
    {
        var candidArgs = CandidArg.FromObjects(args);
        var response = await _agent.CallAsync(
            canisterId: CanisterId,
            method: "icrc1_minting_account",
            arg: candidArgs
        );
        return response.ToObjects<ulong>();
    }
}