using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Duration
	{
		[CandidName("seconds")]
		public OptionalValue<ulong> Seconds { get; set; }

		public Duration(OptionalValue<ulong> seconds)
		{
			this.Seconds = seconds;
		}

		public Duration()
		{
		}
	}
}