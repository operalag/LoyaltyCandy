using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class CanisterIdRange
	{
		[CandidName("end")]
		public Principal End { get; set; }

		[CandidName("start")]
		public Principal Start { get; set; }

		public CanisterIdRange(Principal end, Principal start)
		{
			this.End = end;
			this.Start = start;
		}

		public CanisterIdRange()
		{
		}
	}
}