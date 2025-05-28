using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListProposalInfoResponse
	{
		[CandidName("proposal_info")]
		public List<ProposalInfo> ProposalInfo { get; set; }

		public ListProposalInfoResponse(List<ProposalInfo> proposalInfo)
		{
			this.ProposalInfo = proposalInfo;
		}

		public ListProposalInfoResponse()
		{
		}
	}
}