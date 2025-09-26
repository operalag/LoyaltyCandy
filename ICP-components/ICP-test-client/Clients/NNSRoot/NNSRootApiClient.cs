using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.NNSRoot;
using EdjCase.ICP.Agent.Responses;

namespace LoyaltyCandy.NNSRoot
{
	public class NNSRootApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public NNSRootApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task AddNnsCanister(Models.AddCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_nns_canister", arg);
		}

		public async Task<Models.CanisterStatusResult> CanisterStatus(Models.CanisterIdRecord arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "canister_status", arg);
			return reply.ToObjects<Models.CanisterStatusResult>(this.Converter);
		}

		public async Task<Models.ChangeCanisterControllersResponse> ChangeCanisterControllers(Models.ChangeCanisterControllersRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "change_canister_controllers", arg);
			return reply.ToObjects<Models.ChangeCanisterControllersResponse>(this.Converter);
		}

		public async Task ChangeNnsCanister(Models.ChangeCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "change_nns_canister", arg);
		}

		public async Task<string> GetBuildMetadata()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_build_metadata", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task StopOrStartNnsCanister(Models.StopOrStartCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "stop_or_start_nns_canister", arg);
		}

		public async Task<Models.UpdateCanisterSettingsResponse> UpdateCanisterSettings(Models.UpdateCanisterSettingsRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "update_canister_settings", arg);
			return reply.ToObjects<Models.UpdateCanisterSettingsResponse>(this.Converter);
		}
	}
}