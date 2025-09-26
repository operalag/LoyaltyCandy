using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public enum LogVisibility
	{
		[CandidName("controllers")]
		Controllers,
		[CandidName("public")]
		Public
	}
}