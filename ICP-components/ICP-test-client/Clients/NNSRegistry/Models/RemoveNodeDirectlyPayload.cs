using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class RemoveNodeDirectlyPayload
	{
		[CandidName("node_id")]
		public Principal NodeId { get; set; }

		public RemoveNodeDirectlyPayload(Principal nodeId)
		{
			this.NodeId = nodeId;
		}

		public RemoveNodeDirectlyPayload()
		{
		}
	}
}