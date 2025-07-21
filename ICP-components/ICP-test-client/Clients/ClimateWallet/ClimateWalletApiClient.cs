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

		public async Task<bool> CheckAndMaybeDistributeReward()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "checkAndMaybeDistributeReward", arg);
			return reply.ToObjects<bool>(this.Converter);
		}

		public async Task<string> GetCanisterAccountAddressHex()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getCanisterAccountAddressHex", arg);
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task<Models.PRank> GetCurrentGlobalRanking()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getCurrentGlobalRanking", arg);
			return reply.ToObjects<Models.PRank>(this.Converter);
		}

		public async Task<Models.PRank> GetCurrentWeeklyRanking()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getCurrentWeeklyRanking", arg);
			return reply.ToObjects<Models.PRank>(this.Converter);
		}

		public async Task<Models.GameDataShared> GetGameData()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getGameData", arg);
			return reply.ToObjects<Models.GameDataShared>(this.Converter);
		}

		public async Task<Models.RankingResult> GetGlobalRanking(uint before, uint after, short rank)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(before, this.Converter), CandidTypedValue.FromObject(after, this.Converter), CandidTypedValue.FromObject(rank, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getGlobalRanking", arg);
			return reply.ToObjects<Models.RankingResult>(this.Converter);
		}

		public async Task<string> GetMyCanisterBalanceTxt()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getMyCanisterBalanceTxt", arg);
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task<Models.RankingResult> GetWeeklyRanking(uint before, uint after, short rank)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(before, this.Converter), CandidTypedValue.FromObject(after, this.Converter), CandidTypedValue.FromObject(rank, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getWeeklyRanking", arg);
			return reply.ToObjects<Models.RankingResult>(this.Converter);
		}

		public async Task Ping()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "ping", arg);
		}

		public async Task<uint> ReadScore()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "readScore", arg);
			return reply.ToObjects<uint>(this.Converter);
		}

		public async Task<Models.GameDataShared> RegisterPlayer(string name, bool isMale)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(name, this.Converter), CandidTypedValue.FromObject(isMale, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "registerPlayer", arg);
			return reply.ToObjects<Models.GameDataShared>(this.Converter);
		}

		public async Task ResetPlayerWeeklyRank()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "resetPlayerWeeklyRank", arg);
		}

		public async Task ResetWeeklyPlayerData()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "resetWeeklyPlayerData", arg);
		}

		public async Task RewardClaimed()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "rewardClaimed", arg);
		}

		public async Task<string> ShowRewardAmount()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "showRewardAmount", arg);
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task UpdatePlayerScore(uint newScore)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(newScore, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "updatePlayerScore", arg);
		}
	}
}