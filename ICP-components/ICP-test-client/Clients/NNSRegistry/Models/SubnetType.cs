using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public enum SubnetType
	{
		[CandidName("application")]
		Application,
		[CandidName("verified_application")]
		VerifiedApplication,
		[CandidName("system")]
		System
	}
}