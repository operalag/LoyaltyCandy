using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodeOperatorConfigDirectlyPayload
	{
		[CandidName("node_operator_id")]
		public OptionalValue<Principal> NodeOperatorId { get; set; }

		[CandidName("node_provider_id")]
		public OptionalValue<Principal> NodeProviderId { get; set; }

		public UpdateNodeOperatorConfigDirectlyPayload(OptionalValue<Principal> nodeOperatorId, OptionalValue<Principal> nodeProviderId)
		{
			this.NodeOperatorId = nodeOperatorId;
			this.NodeProviderId = nodeProviderId;
		}

		public UpdateNodeOperatorConfigDirectlyPayload()
		{
		}
	}
}