using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundSnapshot
	{
		[CandidName("neurons_fund_neuron_portions")]
		public List<NeuronsFundNeuronPortion> NeuronsFundNeuronPortions { get; set; }

		public NeuronsFundSnapshot(List<NeuronsFundNeuronPortion> neuronsFundNeuronPortions)
		{
			this.NeuronsFundNeuronPortions = neuronsFundNeuronPortions;
		}

		public NeuronsFundSnapshot()
		{
		}
	}
}