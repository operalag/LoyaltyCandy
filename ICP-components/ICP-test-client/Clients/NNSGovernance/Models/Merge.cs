using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Merge
	{
		[CandidName("source_neuron_id")]
		public OptionalValue<NeuronId> SourceNeuronId { get; set; }

		public Merge(OptionalValue<NeuronId> sourceNeuronId)
		{
			this.SourceNeuronId = sourceNeuronId;
		}

		public Merge()
		{
		}
	}
}