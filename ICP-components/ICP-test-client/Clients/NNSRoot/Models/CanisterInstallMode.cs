using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRoot.Models
{
	public enum CanisterInstallMode
	{
		[CandidName("reinstall")]
		Reinstall,
		[CandidName("upgrade")]
		Upgrade,
		[CandidName("install")]
		Install
	}
}