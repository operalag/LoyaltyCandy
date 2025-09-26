using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRoot.Models
{
	public enum CanisterStatusType
	{
		[CandidName("stopped")]
		Stopped,
		[CandidName("stopping")]
		Stopping,
		[CandidName("running")]
		Running
	}
}