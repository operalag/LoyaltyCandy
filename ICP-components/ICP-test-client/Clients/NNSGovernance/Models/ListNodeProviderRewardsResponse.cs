using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListNodeProviderRewardsResponse
	{
		[CandidName("rewards")]
		public List<MonthlyNodeProviderRewards> Rewards { get; set; }

		public ListNodeProviderRewardsResponse(List<MonthlyNodeProviderRewards> rewards)
		{
			this.Rewards = rewards;
		}

		public ListNodeProviderRewardsResponse()
		{
		}
	}
}