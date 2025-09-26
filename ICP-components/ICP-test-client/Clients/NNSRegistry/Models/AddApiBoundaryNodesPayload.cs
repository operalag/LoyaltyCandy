using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class AddApiBoundaryNodesPayload
	{
		[CandidName("version")]
		public string Version { get; set; }

		[CandidName("node_ids")]
		public List<Principal> NodeIds { get; set; }

		public AddApiBoundaryNodesPayload(string version, List<Principal> nodeIds)
		{
			this.Version = version;
			this.NodeIds = nodeIds;
		}

		public AddApiBoundaryNodesPayload()
		{
		}
	}
}