using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SwapParticipationLimits
	{
		[CandidName("min_participant_icp_e8s")]
		public OptionalValue<ulong> MinParticipantIcpE8s { get; set; }

		[CandidName("max_participant_icp_e8s")]
		public OptionalValue<ulong> MaxParticipantIcpE8s { get; set; }

		[CandidName("min_direct_participation_icp_e8s")]
		public OptionalValue<ulong> MinDirectParticipationIcpE8s { get; set; }

		[CandidName("max_direct_participation_icp_e8s")]
		public OptionalValue<ulong> MaxDirectParticipationIcpE8s { get; set; }

		public SwapParticipationLimits(OptionalValue<ulong> minParticipantIcpE8s, OptionalValue<ulong> maxParticipantIcpE8s, OptionalValue<ulong> minDirectParticipationIcpE8s, OptionalValue<ulong> maxDirectParticipationIcpE8s)
		{
			this.MinParticipantIcpE8s = minParticipantIcpE8s;
			this.MaxParticipantIcpE8s = maxParticipantIcpE8s;
			this.MinDirectParticipationIcpE8s = minDirectParticipationIcpE8s;
			this.MaxDirectParticipationIcpE8s = maxDirectParticipationIcpE8s;
		}

		public SwapParticipationLimits()
		{
		}
	}
}