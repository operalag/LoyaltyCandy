using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class DateRangeFilter
	{
		[CandidName("start_timestamp_seconds")]
		public OptionalValue<ulong> StartTimestampSeconds { get; set; }

		[CandidName("end_timestamp_seconds")]
		public OptionalValue<ulong> EndTimestampSeconds { get; set; }

		public DateRangeFilter(OptionalValue<ulong> startTimestampSeconds, OptionalValue<ulong> endTimestampSeconds)
		{
			this.StartTimestampSeconds = startTimestampSeconds;
			this.EndTimestampSeconds = endTimestampSeconds;
		}

		public DateRangeFilter()
		{
		}
	}
}