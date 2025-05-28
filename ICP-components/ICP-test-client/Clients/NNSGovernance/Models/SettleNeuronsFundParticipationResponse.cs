using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SettleNeuronsFundParticipationResponse
	{
		[CandidName("result")]
		public OptionalValue<Result10> Result { get; set; }

		public SettleNeuronsFundParticipationResponse(OptionalValue<Result10> result)
		{
			this.Result = result;
		}

		public SettleNeuronsFundParticipationResponse()
		{
		}
	}
}