using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ClaimOrRefreshNeuronFromAccountResponse
	{
		[CandidName("result")]
		public OptionalValue<Result1> Result { get; set; }

		public ClaimOrRefreshNeuronFromAccountResponse(OptionalValue<Result1> result)
		{
			this.Result = result;
		}

		public ClaimOrRefreshNeuronFromAccountResponse()
		{
		}
	}
}