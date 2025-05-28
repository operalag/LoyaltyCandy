using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodeDomainDirectlyPayload
	{
		[CandidName("node_id")]
		public Principal NodeId { get; set; }

		[CandidName("domain")]
		public OptionalValue<string> Domain { get; set; }

		public UpdateNodeDomainDirectlyPayload(Principal nodeId, OptionalValue<string> domain)
		{
			this.NodeId = nodeId;
			this.Domain = domain;
		}

		public UpdateNodeDomainDirectlyPayload()
		{
		}
	}
}