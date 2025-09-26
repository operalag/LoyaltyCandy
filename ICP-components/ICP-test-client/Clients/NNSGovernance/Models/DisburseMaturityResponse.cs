using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class DisburseMaturityResponse
	{
		[CandidName("amount_disbursed_e8s")]
		public OptionalValue<ulong> AmountDisbursedE8s { get; set; }

		public DisburseMaturityResponse(OptionalValue<ulong> amountDisbursedE8s)
		{
			this.AmountDisbursedE8s = amountDisbursedE8s;
		}

		public DisburseMaturityResponse()
		{
		}
	}
}