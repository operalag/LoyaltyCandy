using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.NNSDapp;
using EdjCase.ICP.Agent.Responses;
using System.Collections.Generic;
using AccountIdentifier = System.String;

namespace LoyaltyCandy.NNSDapp
{
	public class NNSDappApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public NNSDappApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task<Models.GetAccountResponse> GetAccount()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_account", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetAccountResponse>(this.Converter);
		}

		public async Task<AccountIdentifier> AddAccount()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "add_account", arg);
			return reply.ToObjects<AccountIdentifier>(this.Converter);
		}

		public async Task<Models.CreateSubAccountResponse> CreateSubAccount(string arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "create_sub_account", arg);
			return reply.ToObjects<Models.CreateSubAccountResponse>(this.Converter);
		}

		public async Task<Models.RenameSubAccountResponse> RenameSubAccount(Models.RenameSubAccountRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "rename_sub_account", arg);
			return reply.ToObjects<Models.RenameSubAccountResponse>(this.Converter);
		}

		public async Task<Models.RegisterHardwareWalletResponse> RegisterHardwareWallet(Models.RegisterHardwareWalletRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "register_hardware_wallet", arg);
			return reply.ToObjects<Models.RegisterHardwareWalletResponse>(this.Converter);
		}

		public async Task<List<Models.CanisterDetails>> GetCanisters()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_canisters", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<List<Models.CanisterDetails>>(this.Converter);
		}

		public async Task<Models.AttachCanisterResponse> AttachCanister(Models.AttachCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "attach_canister", arg);
			return reply.ToObjects<Models.AttachCanisterResponse>(this.Converter);
		}

		public async Task<Models.RenameCanisterResponse> RenameCanister(Models.RenameCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "rename_canister", arg);
			return reply.ToObjects<Models.RenameCanisterResponse>(this.Converter);
		}

		public async Task<Models.DetachCanisterResponse> DetachCanister(Models.DetachCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "detach_canister", arg);
			return reply.ToObjects<Models.DetachCanisterResponse>(this.Converter);
		}

		public async Task<Models.GetProposalPayloadResponse> GetProposalPayload(ulong arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "get_proposal_payload", arg);
			return reply.ToObjects<Models.GetProposalPayloadResponse>(this.Converter);
		}

		public async Task<Models.Stats> GetStats()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_stats", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.Stats>(this.Converter);
		}

		public async Task<Models.Histogram> GetHistogram()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_histogram", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.Histogram>(this.Converter);
		}

		public async Task<List<ulong>> GetExceptionalTransactions()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_exceptional_transactions", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<List<ulong>>(this.Converter);
		}

		public async Task<Models.HttpResponse> HttpRequest(Models.HttpRequest request)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(request, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "http_request", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.HttpResponse>(this.Converter);
		}

		public async Task AddStableAsset(List<byte> asset)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(asset, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_stable_asset", arg);
		}

		public async Task AddAssetsTarXz(List<byte> asset)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(asset, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_assets_tar_xz", arg);
		}

		public async Task StepMigration(uint arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "step_migration", arg);
		}

		public async Task<Models.GetAccountResponse> GetToyAccount(ulong arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_toy_account", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetAccountResponse>(this.Converter);
		}
	}
}