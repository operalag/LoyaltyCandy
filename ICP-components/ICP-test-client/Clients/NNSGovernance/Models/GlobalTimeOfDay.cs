using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class GlobalTimeOfDay
	{
		[CandidName("seconds_after_utc_midnight")]
		public OptionalValue<ulong> SecondsAfterUtcMidnight { get; set; }

		public GlobalTimeOfDay(OptionalValue<ulong> secondsAfterUtcMidnight)
		{
			this.SecondsAfterUtcMidnight = secondsAfterUtcMidnight;
		}

		public GlobalTimeOfDay()
		{
		}
	}
}