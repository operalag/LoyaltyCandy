using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.NNSRegistry;
using EdjCase.ICP.Agent.Responses;

namespace LoyaltyCandy.NNSRegistry
{
	public class NNSRegistryApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public NNSRegistryApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task AddApiBoundaryNodes(Models.AddApiBoundaryNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_api_boundary_nodes", arg);
		}

		public async Task AddFirewallRules(Models.AddFirewallRulesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_firewall_rules", arg);
		}

		public async Task<Principal> AddNode(Models.AddNodePayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "add_node", arg);
			return reply.ToObjects<Principal>(this.Converter);
		}

		public async Task AddNodeOperator(Models.AddNodeOperatorPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_node_operator", arg);
		}

		public async Task AddNodesToSubnet(Models.AddNodesToSubnetPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_nodes_to_subnet", arg);
		}

		public async Task AddOrRemoveDataCenters(Models.AddOrRemoveDataCentersProposalPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add_or_remove_data_centers", arg);
		}

		public async Task ChangeSubnetMembership(Models.ChangeSubnetMembershipPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "change_subnet_membership", arg);
		}

		public async Task ClearProvisionalWhitelist()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "clear_provisional_whitelist", arg);
		}

		public async Task CompleteCanisterMigration(Models.CompleteCanisterMigrationPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "complete_canister_migration", arg);
		}

		public async Task CreateSubnet(Models.CreateSubnetPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "create_subnet", arg);
		}

		public async Task DeployGuestosToAllSubnetNodes(Models.DeployGuestosToAllSubnetNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "deploy_guestos_to_all_subnet_nodes", arg);
		}

		public async Task DeployGuestosToAllUnassignedNodes(Models.DeployGuestosToAllUnassignedNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "deploy_guestos_to_all_unassigned_nodes", arg);
		}

		public async Task DeployGuestosToSomeApiBoundaryNodes(Models.DeployGuestosToSomeApiBoundaryNodes arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "deploy_guestos_to_some_api_boundary_nodes", arg);
		}

		public async Task DeployHostosToSomeNodes(Models.DeployHostosToSomeNodes arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "deploy_hostos_to_some_nodes", arg);
		}

		public async Task<Models.GetApiBoundaryNodeIdsResponse> GetApiBoundaryNodeIds(Models.GetApiBoundaryNodeIdsRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_api_boundary_node_ids", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetApiBoundaryNodeIdsResponse>(this.Converter);
		}

		public async Task<string> GetBuildMetadata()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_build_metadata", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<string>(this.Converter);
		}

		public async Task<Models.GetChunkResponse> GetChunk(Models.GetChunkRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_chunk", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetChunkResponse>(this.Converter);
		}

		public async Task<Models.GetNodeOperatorsAndDcsOfNodeProviderResponse> GetNodeOperatorsAndDcsOfNodeProvider(Principal arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_node_operators_and_dcs_of_node_provider", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetNodeOperatorsAndDcsOfNodeProviderResponse>(this.Converter);
		}

		public async Task<Models.GetNodeProvidersMonthlyXdrRewardsResponse> GetNodeProvidersMonthlyXdrRewards()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_node_providers_monthly_xdr_rewards", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetNodeProvidersMonthlyXdrRewardsResponse>(this.Converter);
		}

		public async Task<Models.GetSubnetForCanisterResponse> GetSubnetForCanister(Models.GetSubnetForCanisterRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_subnet_for_canister", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetSubnetForCanisterResponse>(this.Converter);
		}

		public async Task PrepareCanisterMigration(Models.PrepareCanisterMigrationPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "prepare_canister_migration", arg);
		}

		public async Task RecoverSubnet(Models.RecoverSubnetPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "recover_subnet", arg);
		}

		public async Task RemoveApiBoundaryNodes(Models.RemoveApiBoundaryNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove_api_boundary_nodes", arg);
		}

		public async Task RemoveFirewallRules(Models.RemoveFirewallRulesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove_firewall_rules", arg);
		}

		public async Task RemoveNodeDirectly(Models.RemoveNodeDirectlyPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove_node_directly", arg);
		}

		public async Task RemoveNodeOperators(Models.RemoveNodeOperatorsPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove_node_operators", arg);
		}

		public async Task RemoveNodes(Models.RemoveNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove_nodes", arg);
		}

		public async Task RemoveNodesFromSubnet(Models.RemoveNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove_nodes_from_subnet", arg);
		}

		public async Task RerouteCanisterRanges(Models.RerouteCanisterRangesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "reroute_canister_ranges", arg);
		}

		public async Task ReviseElectedGuestosVersions(Models.ReviseElectedGuestosVersionsPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "revise_elected_guestos_versions", arg);
		}

		public async Task ReviseElectedReplicaVersions(Models.ReviseElectedGuestosVersionsPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "revise_elected_replica_versions", arg);
		}

		public async Task SetFirewallConfig(Models.SetFirewallConfigPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "set_firewall_config", arg);
		}

		public async Task UpdateApiBoundaryNodesVersion(Models.UpdateApiBoundaryNodesVersionPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_api_boundary_nodes_version", arg);
		}

		public async Task UpdateElectedHostosVersions(Models.UpdateElectedHostosVersionsPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_elected_hostos_versions", arg);
		}

		public async Task ReviseElectedHostosVersions(Models.ReviseElectedHostosVersionsPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "revise_elected_hostos_versions", arg);
		}

		public async Task UpdateFirewallRules(Models.UpdateFirewallRulesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_firewall_rules", arg);
		}

		public async Task UpdateNodeDirectly(Models.UpdateNodeDirectlyPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_node_directly", arg);
		}

		public async Task<Models.UpdateNodeDomainDirectlyResponse> UpdateNodeDomainDirectly(Models.UpdateNodeDomainDirectlyPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "update_node_domain_directly", arg);
			return reply.ToObjects<Models.UpdateNodeDomainDirectlyResponse>(this.Converter);
		}

		public async Task<Models.UpdateNodeIpv4ConfigDirectlyResponse> UpdateNodeIpv4ConfigDirectly(Models.UpdateNodeIPv4ConfigDirectlyPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "update_node_ipv4_config_directly", arg);
			return reply.ToObjects<Models.UpdateNodeIpv4ConfigDirectlyResponse>(this.Converter);
		}

		public async Task UpdateNodeOperatorConfig(Models.UpdateNodeOperatorConfigPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_node_operator_config", arg);
		}

		public async Task UpdateNodeOperatorConfigDirectly(Models.UpdateNodeOperatorConfigDirectlyPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_node_operator_config_directly", arg);
		}

		public async Task UpdateNodeRewardsTable(Models.UpdateNodeRewardsTableProposalPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_node_rewards_table", arg);
		}

		public async Task UpdateNodesHostosVersion(Models.UpdateNodesHostosVersionPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_nodes_hostos_version", arg);
		}

		public async Task UpdateSshReadonlyAccessForAllUnassignedNodes(Models.UpdateSshReadOnlyAccessForAllUnassignedNodesPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_ssh_readonly_access_for_all_unassigned_nodes", arg);
		}

		public async Task UpdateSubnet(Models.UpdateSubnetPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_subnet", arg);
		}

		public async Task UpdateUnassignedNodesConfig(Models.UpdateUnassignedNodesConfigPayload arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update_unassigned_nodes_config", arg);
		}
	}
}