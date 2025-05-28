using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class MakeProposalResponse
	{
		[CandidName("message")]
		public OptionalValue<string> Message { get; set; }

		[CandidName("proposal_id")]
		public OptionalValue<ProposalId> ProposalId { get; set; }

		public MakeProposalResponse(OptionalValue<string> message, OptionalValue<ProposalId> proposalId)
		{
			this.Message = message;
			this.ProposalId = proposalId;
		}

		public MakeProposalResponse()
		{
		}
	}
}