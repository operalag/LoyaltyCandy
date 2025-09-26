using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListNodeProviderRewardsRequest
	{
		[CandidName("date_filter")]
		public OptionalValue<DateRangeFilter> DateFilter { get; set; }

		public ListNodeProviderRewardsRequest(OptionalValue<DateRangeFilter> dateFilter)
		{
			this.DateFilter = dateFilter;
		}

		public ListNodeProviderRewardsRequest()
		{
		}
	}
}