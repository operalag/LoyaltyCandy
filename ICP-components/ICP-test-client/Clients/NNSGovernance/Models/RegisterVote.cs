using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class RegisterVote
	{
		[CandidName("vote")]
		public int Vote { get; set; }

		[CandidName("proposal")]
		public OptionalValue<ProposalId> Proposal { get; set; }

		public RegisterVote(int vote, OptionalValue<ProposalId> proposal)
		{
			this.Vote = vote;
			this.Proposal = proposal;
		}

		public RegisterVote()
		{
		}
	}
}