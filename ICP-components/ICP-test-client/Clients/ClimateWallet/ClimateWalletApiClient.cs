using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.ClimateWallet;

namespace LoyaltyCandy.ClimateWallet
{
	public class ClimateWalletApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public ClimateWalletApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task<uint> Bump()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "bump", arg);
			return reply.ToObjects<uint>(this.Converter);
		}

		public async Task<Models.PRank> GetCurrentRanking()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getCurrentRanking", arg);
			return reply.ToObjects<Models.PRank>(this.Converter);
		}

		public async Task<Models.RankingResult> GetRanking(uint arg0, uint arg1, short arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getRanking", arg);
			return reply.ToObjects<Models.RankingResult>(this.Converter);
		}

		public async Task Inc()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "inc", arg);
		}

		public async Task<uint> Read()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "read", arg);
			return reply.ToObjects<uint>(this.Converter);
		}

		public async Task<uint> Set(uint arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "set", arg);
			return reply.ToObjects<uint>(this.Converter);
		}
	}
}