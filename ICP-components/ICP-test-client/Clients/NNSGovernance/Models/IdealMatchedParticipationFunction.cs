using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class IdealMatchedParticipationFunction
	{
		[CandidName("serialized_representation")]
		public OptionalValue<string> SerializedRepresentation { get; set; }

		public IdealMatchedParticipationFunction(OptionalValue<string> serializedRepresentation)
		{
			this.SerializedRepresentation = serializedRepresentation;
		}

		public IdealMatchedParticipationFunction()
		{
		}
	}
}