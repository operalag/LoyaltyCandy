using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodesHostosVersionPayload
	{
		[CandidName("hostos_version_id")]
		public OptionalValue<string> HostosVersionId { get; set; }

		[CandidName("node_ids")]
		public List<Principal> NodeIds { get; set; }

		public UpdateNodesHostosVersionPayload(OptionalValue<string> hostosVersionId, List<Principal> nodeIds)
		{
			this.HostosVersionId = hostosVersionId;
			this.NodeIds = nodeIds;
		}

		public UpdateNodesHostosVersionPayload()
		{
		}
	}
}