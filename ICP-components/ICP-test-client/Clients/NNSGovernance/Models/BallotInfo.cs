using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class BallotInfo
	{
		[CandidName("vote")]
		public int Vote { get; set; }

		[CandidName("proposal_id")]
		public OptionalValue<ProposalId> ProposalId { get; set; }

		public BallotInfo(int vote, OptionalValue<ProposalId> proposalId)
		{
			this.Vote = vote;
			this.ProposalId = proposalId;
		}

		public BallotInfo()
		{
		}
	}
}