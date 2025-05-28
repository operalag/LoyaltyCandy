using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class NodeRewardRates
	{
		[CandidName("rates")]
		public Dictionary<string, NodeRewardRate> Rates { get; set; }

		public NodeRewardRates(Dictionary<string, NodeRewardRate> rates)
		{
			this.Rates = rates;
		}

		public NodeRewardRates()
		{
		}
	}
}