using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SetOpenTimeWindowRequest
	{
		[CandidName("open_time_window")]
		public OptionalValue<TimeWindow> OpenTimeWindow { get; set; }

		public SetOpenTimeWindowRequest(OptionalValue<TimeWindow> openTimeWindow)
		{
			this.OpenTimeWindow = openTimeWindow;
		}

		public SetOpenTimeWindowRequest()
		{
		}
	}
}