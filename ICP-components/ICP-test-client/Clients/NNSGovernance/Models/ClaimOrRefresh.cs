using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ClaimOrRefresh
	{
		[CandidName("by")]
		public OptionalValue<By> By { get; set; }

		public ClaimOrRefresh(OptionalValue<By> by)
		{
			this.By = by;
		}

		public ClaimOrRefresh()
		{
		}
	}
}