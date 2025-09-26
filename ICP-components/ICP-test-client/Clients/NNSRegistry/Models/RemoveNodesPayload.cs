using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class RemoveNodesPayload
	{
		[CandidName("node_ids")]
		public List<Principal> NodeIds { get; set; }

		public RemoveNodesPayload(List<Principal> nodeIds)
		{
			this.NodeIds = nodeIds;
		}

		public RemoveNodesPayload()
		{
		}
	}
}