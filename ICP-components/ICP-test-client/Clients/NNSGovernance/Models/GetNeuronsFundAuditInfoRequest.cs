using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class GetNeuronsFundAuditInfoRequest
	{
		[CandidName("nns_proposal_id")]
		public OptionalValue<ProposalId> NnsProposalId { get; set; }

		public GetNeuronsFundAuditInfoRequest(OptionalValue<ProposalId> nnsProposalId)
		{
			this.NnsProposalId = nnsProposalId;
		}

		public GetNeuronsFundAuditInfoRequest()
		{
		}
	}
}