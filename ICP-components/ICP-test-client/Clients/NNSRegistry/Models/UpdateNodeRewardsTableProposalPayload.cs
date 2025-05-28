using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodeRewardsTableProposalPayload
	{
		[CandidName("new_entries")]
		public Dictionary<string, NodeRewardRates> NewEntries { get; set; }

		public UpdateNodeRewardsTableProposalPayload(Dictionary<string, NodeRewardRates> newEntries)
		{
			this.NewEntries = newEntries;
		}

		public UpdateNodeRewardsTableProposalPayload()
		{
		}
	}
}