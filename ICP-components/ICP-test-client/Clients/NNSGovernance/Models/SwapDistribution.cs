using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SwapDistribution
	{
		[CandidName("total")]
		public OptionalValue<Tokens> Total { get; set; }

		public SwapDistribution(OptionalValue<Tokens> total)
		{
			this.Total = total;
		}

		public SwapDistribution()
		{
		}
	}
}