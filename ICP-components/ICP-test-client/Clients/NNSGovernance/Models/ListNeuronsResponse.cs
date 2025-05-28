using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListNeuronsResponse
	{
		[CandidName("neuron_infos")]
		public Dictionary<ulong, NeuronInfo> NeuronInfos { get; set; }

		[CandidName("full_neurons")]
		public List<Neuron> FullNeurons { get; set; }

		[CandidName("total_pages_available")]
		public OptionalValue<ulong> TotalPagesAvailable { get; set; }

		public ListNeuronsResponse(Dictionary<ulong, NeuronInfo> neuronInfos, List<Neuron> fullNeurons, OptionalValue<ulong> totalPagesAvailable)
		{
			this.NeuronInfos = neuronInfos;
			this.FullNeurons = fullNeurons;
			this.TotalPagesAvailable = totalPagesAvailable;
		}

		public ListNeuronsResponse()
		{
		}
	}
}