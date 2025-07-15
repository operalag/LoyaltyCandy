using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.ClimateWallet;
using System.Collections.Generic;

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

		public async Task<Models.GameDataShared> GetGameData()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getGameData", arg);
			return reply.ToObjects<Models.GameDataShared>(this.Converter);
		}

		public async Task<string> GetMyCanisterBalanceTxt()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getMyCanisterBalanceTxt", arg);
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task<Models.RankingResult> GetRanking(uint before, uint after, short rank)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(before, this.Converter), CandidTypedValue.FromObject(after, this.Converter), CandidTypedValue.FromObject(rank, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getRanking", arg);
			return reply.ToObjects<Models.RankingResult>(this.Converter);
		}

		public async Task<List<Models.GameDataWithPrincipal>> GetTopRankingWithPrincipal()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getTopRankingWithPrincipal", arg);
			return reply.ToObjects<List<Models.GameDataWithPrincipal>>(this.Converter);
		}

		public async Task RegisterPlayer(string name, bool isMale)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(name, this.Converter), CandidTypedValue.FromObject(isMale, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "registerPlayer", arg);
		}

		public async Task RewardTop10(UnboundedUInt amountPerPlayerE8s)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(amountPerPlayerE8s, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "rewardTop10", arg);
		}

		public async Task UpdatePlayerScore(uint newScore)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(newScore, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "updatePlayerScore", arg);
		}
	}
}