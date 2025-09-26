using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class NodeRewardRate
	{
		[CandidName("xdr_permyriad_per_node_per_month")]
		public ulong XdrPermyriadPerNodePerMonth { get; set; }

		[CandidName("reward_coefficient_percent")]
		public OptionalValue<int> RewardCoefficientPercent { get; set; }

		public NodeRewardRate(ulong xdrPermyriadPerNodePerMonth, OptionalValue<int> rewardCoefficientPercent)
		{
			this.XdrPermyriadPerNodePerMonth = xdrPermyriadPerNodePerMonth;
			this.RewardCoefficientPercent = rewardCoefficientPercent;
		}

		public NodeRewardRate()
		{
		}
	}
}