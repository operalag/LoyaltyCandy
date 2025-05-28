using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class GetNeuronsFundAuditInfoResponse
	{
		[CandidName("result")]
		public OptionalValue<Result6> Result { get; set; }

		public GetNeuronsFundAuditInfoResponse(OptionalValue<Result6> result)
		{
			this.Result = result;
		}

		public GetNeuronsFundAuditInfoResponse()
		{
		}
	}
}