using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public enum Purpose
	{
		[CandidName("recovery")]
		Recovery,
		[CandidName("authentication")]
		Authentication
	}
}