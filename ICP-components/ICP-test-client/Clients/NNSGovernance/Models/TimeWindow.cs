using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class TimeWindow
	{
		[CandidName("start_timestamp_seconds")]
		public ulong StartTimestampSeconds { get; set; }

		[CandidName("end_timestamp_seconds")]
		public ulong EndTimestampSeconds { get; set; }

		public TimeWindow(ulong startTimestampSeconds, ulong endTimestampSeconds)
		{
			this.StartTimestampSeconds = startTimestampSeconds;
			this.EndTimestampSeconds = endTimestampSeconds;
		}

		public TimeWindow()
		{
		}
	}
}