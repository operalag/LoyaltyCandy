using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public enum DeviceProtection
	{
		[CandidName("protected")]
		Protected,
		[CandidName("unprotected")]
		Unprotected
	}
}