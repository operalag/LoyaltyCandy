using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.NNSCyclesMinting;
using EdjCase.ICP.Agent.Responses;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSCyclesMinting
{
	public class NNSCyclesMintingApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public NNSCyclesMintingApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task<Models.NotifyTopUpResult> NotifyTopUp(Models.NotifyTopUpArg arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "notify_top_up", arg);
			return reply.ToObjects<Models.NotifyTopUpResult>(this.Converter);
		}

		public async Task<Models.CreateCanisterResult> CreateCanister(Models.CreateCanisterArg arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "create_canister", arg);
			return reply.ToObjects<Models.CreateCanisterResult>(this.Converter);
		}

		public async Task<Models.NotifyCreateCanisterResult> NotifyCreateCanister(Models.NotifyCreateCanisterArg arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "notify_create_canister", arg);
			return reply.ToObjects<Models.NotifyCreateCanisterResult>(this.Converter);
		}

		public async Task<Models.NotifyMintCyclesResult> NotifyMintCycles(Models.NotifyMintCyclesArg arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "notify_mint_cycles", arg);
			return reply.ToObjects<Models.NotifyMintCyclesResult>(this.Converter);
		}

		public async Task<Models.IcpXdrConversionRateResponse> GetIcpXdrConversionRate()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_icp_xdr_conversion_rate", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.IcpXdrConversionRateResponse>(this.Converter);
		}

		public async Task<Models.SubnetTypesToSubnetsResponse> GetSubnetTypesToSubnets()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_subnet_types_to_subnets", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.SubnetTypesToSubnetsResponse>(this.Converter);
		}

		public async Task<Models.PrincipalsAuthorizedToCreateCanistersToSubnetsResponse> GetPrincipalsAuthorizedToCreateCanistersToSubnets()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_principals_authorized_to_create_canisters_to_subnets", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.PrincipalsAuthorizedToCreateCanistersToSubnetsResponse>(this.Converter);
		}

		public async Task<List<Principal>> GetDefaultSubnets()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_default_subnets", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<List<Principal>>(this.Converter);
		}

		public async Task<string> GetBuildMetadata()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_build_metadata", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<string>(this.Converter);
		}
	}
}