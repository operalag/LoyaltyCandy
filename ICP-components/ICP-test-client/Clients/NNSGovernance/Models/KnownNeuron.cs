using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class KnownNeuron
	{
		[CandidName("id")]
		public OptionalValue<NeuronId> Id { get; set; }

		[CandidName("known_neuron_data")]
		public OptionalValue<KnownNeuronData> KnownNeuronData { get; set; }

		public KnownNeuron(OptionalValue<NeuronId> id, OptionalValue<KnownNeuronData> knownNeuronData)
		{
			this.Id = id;
			this.KnownNeuronData = knownNeuronData;
		}

		public KnownNeuron()
		{
		}
	}
}