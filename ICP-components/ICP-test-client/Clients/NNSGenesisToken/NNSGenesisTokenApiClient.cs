using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Responses;
using LoyaltyCandy.NNSGenesisToken;

namespace LoyaltyCandy.NNSGenesisToken
{
	public class NNSGenesisTokenApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public NNSGenesisTokenApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task<uint> Balance(string arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "balance", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<uint>(this.Converter);
		}

		public async Task<Models.Result> ClaimNeurons(string arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "claim_neurons", arg);
			return reply.ToObjects<Models.Result>(this.Converter);
		}

		public async Task<Models.Result1> DonateAccount(string arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "donate_account", arg);
			return reply.ToObjects<Models.Result1>(this.Converter);
		}

		public async Task<Models.Result1> ForwardWhitelistedUnclaimedAccounts(NullValue arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "forward_whitelisted_unclaimed_accounts", arg);
			return reply.ToObjects<Models.Result1>(this.Converter);
		}

		public async Task<Models.Result2> GetAccount(string arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_account", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.Result2>(this.Converter);
		}

		public async Task<string> GetBuildMetadata()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_build_metadata", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task<ushort> Len()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "len", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<ushort>(this.Converter);
		}

		public async Task<uint> Total()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "total", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<uint>(this.Converter);
		}
	}
}