using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class AddNodesToSubnetPayload
	{
		[CandidName("subnet_id")]
		public Principal SubnetId { get; set; }

		[CandidName("node_ids")]
		public List<Principal> NodeIds { get; set; }

		public AddNodesToSubnetPayload(Principal subnetId, List<Principal> nodeIds)
		{
			this.SubnetId = subnetId;
			this.NodeIds = nodeIds;
		}

		public AddNodesToSubnetPayload()
		{
		}
	}
}