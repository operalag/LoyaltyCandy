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

		public async Task<UnboundedUInt> GetMyBalance()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getMyBalance", arg);
			return reply.ToObjects<UnboundedUInt>(this.Converter);
		}

		public async Task<string> GetMyBalanceTxt()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "getMyBalanceTxt", arg);
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task<Models.RankingResult> GetRanking(uint before, uint after, short rank)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(before, this.Converter), CandidTypedValue.FromObject(after, this.Converter), CandidTypedValue.FromObject(rank, this.Converter));
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

		public async Task<(OptionalValue<Models.GameData> ReturnArg0, string ReturnArg1)> ReadGameData()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "readGameData", arg);
			return reply.ToObjects<OptionalValue<Models.GameData>, string>(this.Converter);
		}

		public async Task<UnboundedUInt> SendIcp(Principal to, UnboundedUInt amountE8s)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(to, this.Converter), CandidTypedValue.FromObject(amountE8s, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "sendIcp", arg);
			return reply.ToObjects<UnboundedUInt>(this.Converter);
		}

		public async Task<uint> Set(uint value)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(value, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "set", arg);
			return reply.ToObjects<uint>(this.Converter);
		}

		public async Task<(Models.GameData ReturnArg0, string ReturnArg1)> WriteGameData(bool isMale, double gem)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(isMale, this.Converter), CandidTypedValue.FromObject(gem, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "writeGameData", arg);
			return reply.ToObjects<Models.GameData, string>(this.Converter);
		}
	}
}