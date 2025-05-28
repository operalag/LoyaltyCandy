using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class DeveloperDistribution
	{
		[CandidName("developer_neurons")]
		public List<NeuronDistribution> DeveloperNeurons { get; set; }

		public DeveloperDistribution(List<NeuronDistribution> developerNeurons)
		{
			this.DeveloperNeurons = developerNeurons;
		}

		public DeveloperDistribution()
		{
		}
	}
}