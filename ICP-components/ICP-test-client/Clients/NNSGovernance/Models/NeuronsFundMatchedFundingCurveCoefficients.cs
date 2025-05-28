using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundMatchedFundingCurveCoefficients
	{
		[CandidName("contribution_threshold_xdr")]
		public OptionalValue<Decimal> ContributionThresholdXdr { get; set; }

		[CandidName("one_third_participation_milestone_xdr")]
		public OptionalValue<Decimal> OneThirdParticipationMilestoneXdr { get; set; }

		[CandidName("full_participation_milestone_xdr")]
		public OptionalValue<Decimal> FullParticipationMilestoneXdr { get; set; }

		public NeuronsFundMatchedFundingCurveCoefficients(OptionalValue<Decimal> contributionThresholdXdr, OptionalValue<Decimal> oneThirdParticipationMilestoneXdr, OptionalValue<Decimal> fullParticipationMilestoneXdr)
		{
			this.ContributionThresholdXdr = contributionThresholdXdr;
			this.OneThirdParticipationMilestoneXdr = oneThirdParticipationMilestoneXdr;
			this.FullParticipationMilestoneXdr = fullParticipationMilestoneXdr;
		}

		public NeuronsFundMatchedFundingCurveCoefficients()
		{
		}
	}
}