using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodeOperatorConfigPayload
	{
		[CandidName("node_operator_id")]
		public OptionalValue<Principal> NodeOperatorId { get; set; }

		[CandidName("set_ipv6_to_none")]
		public OptionalValue<bool> SetIpv6ToNone { get; set; }

		[CandidName("ipv6")]
		public OptionalValue<string> Ipv6 { get; set; }

		[CandidName("node_provider_id")]
		public OptionalValue<Principal> NodeProviderId { get; set; }

		[CandidName("node_allowance")]
		public OptionalValue<ulong> NodeAllowance { get; set; }

		[CandidName("rewardable_nodes")]
		public Dictionary<string, uint> RewardableNodes { get; set; }

		[CandidName("dc_id")]
		public OptionalValue<string> DcId { get; set; }

		public UpdateNodeOperatorConfigPayload(OptionalValue<Principal> nodeOperatorId, OptionalValue<bool> setIpv6ToNone, OptionalValue<string> ipv6, OptionalValue<Principal> nodeProviderId, OptionalValue<ulong> nodeAllowance, Dictionary<string, uint> rewardableNodes, OptionalValue<string> dcId)
		{
			this.NodeOperatorId = nodeOperatorId;
			this.SetIpv6ToNone = setIpv6ToNone;
			this.Ipv6 = ipv6;
			this.NodeProviderId = nodeProviderId;
			this.NodeAllowance = nodeAllowance;
			this.RewardableNodes = rewardableNodes;
			this.DcId = dcId;
		}

		public UpdateNodeOperatorConfigPayload()
		{
		}
	}
}