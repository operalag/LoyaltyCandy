using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class AddNodeOperatorPayload
	{
		[CandidName("ipv6")]
		public OptionalValue<string> Ipv6 { get; set; }

		[CandidName("node_operator_principal_id")]
		public OptionalValue<Principal> NodeOperatorPrincipalId { get; set; }

		[CandidName("node_allowance")]
		public ulong NodeAllowance { get; set; }

		[CandidName("rewardable_nodes")]
		public Dictionary<string, uint> RewardableNodes { get; set; }

		[CandidName("node_provider_principal_id")]
		public OptionalValue<Principal> NodeProviderPrincipalId { get; set; }

		[CandidName("dc_id")]
		public string DcId { get; set; }

		public AddNodeOperatorPayload(OptionalValue<string> ipv6, OptionalValue<Principal> nodeOperatorPrincipalId, ulong nodeAllowance, Dictionary<string, uint> rewardableNodes, OptionalValue<Principal> nodeProviderPrincipalId, string dcId)
		{
			this.Ipv6 = ipv6;
			this.NodeOperatorPrincipalId = nodeOperatorPrincipalId;
			this.NodeAllowance = nodeAllowance;
			this.RewardableNodes = rewardableNodes;
			this.NodeProviderPrincipalId = nodeProviderPrincipalId;
			this.DcId = dcId;
		}

		public AddNodeOperatorPayload()
		{
		}
	}
}