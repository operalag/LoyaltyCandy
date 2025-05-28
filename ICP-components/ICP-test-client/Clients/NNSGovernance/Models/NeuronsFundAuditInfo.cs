using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundAuditInfo
	{
		[CandidName("final_neurons_fund_participation")]
		public OptionalValue<NeuronsFundParticipation> FinalNeuronsFundParticipation { get; set; }

		[CandidName("initial_neurons_fund_participation")]
		public OptionalValue<NeuronsFundParticipation> InitialNeuronsFundParticipation { get; set; }

		[CandidName("neurons_fund_refunds")]
		public OptionalValue<NeuronsFundSnapshot> NeuronsFundRefunds { get; set; }

		public NeuronsFundAuditInfo(OptionalValue<NeuronsFundParticipation> finalNeuronsFundParticipation, OptionalValue<NeuronsFundParticipation> initialNeuronsFundParticipation, OptionalValue<NeuronsFundSnapshot> neuronsFundRefunds)
		{
			this.FinalNeuronsFundParticipation = finalNeuronsFundParticipation;
			this.InitialNeuronsFundParticipation = initialNeuronsFundParticipation;
			this.NeuronsFundRefunds = neuronsFundRefunds;
		}

		public NeuronsFundAuditInfo()
		{
		}
	}
}