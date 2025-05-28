using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SettleCommunityFundParticipation
	{
		[CandidName("result")]
		public OptionalValue<Result8> Result { get; set; }

		[CandidName("open_sns_token_swap_proposal_id")]
		public OptionalValue<ulong> OpenSnsTokenSwapProposalId { get; set; }

		public SettleCommunityFundParticipation(OptionalValue<Result8> result, OptionalValue<ulong> openSnsTokenSwapProposalId)
		{
			this.Result = result;
			this.OpenSnsTokenSwapProposalId = openSnsTokenSwapProposalId;
		}

		public SettleCommunityFundParticipation()
		{
		}
	}
}