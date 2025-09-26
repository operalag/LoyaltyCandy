using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRoot.Models
{
	public enum LogVisibility
	{
		[CandidName("controllers")]
		Controllers,
		[CandidName("public")]
		Public
	}
}