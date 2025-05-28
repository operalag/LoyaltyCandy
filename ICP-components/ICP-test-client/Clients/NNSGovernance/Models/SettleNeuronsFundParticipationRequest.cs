using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SettleNeuronsFundParticipationRequest
	{
		[CandidName("result")]
		public OptionalValue<Result9> Result { get; set; }

		[CandidName("nns_proposal_id")]
		public OptionalValue<ulong> NnsProposalId { get; set; }

		public SettleNeuronsFundParticipationRequest(OptionalValue<Result9> result, OptionalValue<ulong> nnsProposalId)
		{
			this.Result = result;
			this.NnsProposalId = nnsProposalId;
		}

		public SettleNeuronsFundParticipationRequest()
		{
		}
	}
}