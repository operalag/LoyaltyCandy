using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Ok1
	{
		[CandidName("neurons_fund_neuron_portions")]
		public List<NeuronsFundNeuron> NeuronsFundNeuronPortions { get; set; }

		public Ok1(List<NeuronsFundNeuron> neuronsFundNeuronPortions)
		{
			this.NeuronsFundNeuronPortions = neuronsFundNeuronPortions;
		}

		public Ok1()
		{
		}
	}
}