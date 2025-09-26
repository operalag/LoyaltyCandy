using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Committed1
	{
		[CandidName("total_direct_participation_icp_e8s")]
		public OptionalValue<ulong> TotalDirectParticipationIcpE8s { get; set; }

		[CandidName("total_neurons_fund_participation_icp_e8s")]
		public OptionalValue<ulong> TotalNeuronsFundParticipationIcpE8s { get; set; }

		[CandidName("sns_governance_canister_id")]
		public OptionalValue<Principal> SnsGovernanceCanisterId { get; set; }

		public Committed1(OptionalValue<ulong> totalDirectParticipationIcpE8s, OptionalValue<ulong> totalNeuronsFundParticipationIcpE8s, OptionalValue<Principal> snsGovernanceCanisterId)
		{
			this.TotalDirectParticipationIcpE8s = totalDirectParticipationIcpE8s;
			this.TotalNeuronsFundParticipationIcpE8s = totalNeuronsFundParticipationIcpE8s;
			this.SnsGovernanceCanisterId = snsGovernanceCanisterId;
		}

		public Committed1()
		{
		}
	}
}