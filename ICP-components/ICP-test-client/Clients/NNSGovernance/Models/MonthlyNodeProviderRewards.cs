using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class MonthlyNodeProviderRewards
	{
		[CandidName("minimum_xdr_permyriad_per_icp")]
		public OptionalValue<ulong> MinimumXdrPermyriadPerIcp { get; set; }

		[CandidName("registry_version")]
		public OptionalValue<ulong> RegistryVersion { get; set; }

		[CandidName("node_providers")]
		public List<NodeProvider> NodeProviders { get; set; }

		[CandidName("timestamp")]
		public ulong Timestamp { get; set; }

		[CandidName("rewards")]
		public List<RewardNodeProvider> Rewards { get; set; }

		[CandidName("xdr_conversion_rate")]
		public OptionalValue<XdrConversionRate> XdrConversionRate { get; set; }

		[CandidName("maximum_node_provider_rewards_e8s")]
		public OptionalValue<ulong> MaximumNodeProviderRewardsE8s { get; set; }

		public MonthlyNodeProviderRewards(OptionalValue<ulong> minimumXdrPermyriadPerIcp, OptionalValue<ulong> registryVersion, List<NodeProvider> nodeProviders, ulong timestamp, List<RewardNodeProvider> rewards, OptionalValue<XdrConversionRate> xdrConversionRate, OptionalValue<ulong> maximumNodeProviderRewardsE8s)
		{
			this.MinimumXdrPermyriadPerIcp = minimumXdrPermyriadPerIcp;
			this.RegistryVersion = registryVersion;
			this.NodeProviders = nodeProviders;
			this.Timestamp = timestamp;
			this.Rewards = rewards;
			this.XdrConversionRate = xdrConversionRate;
			this.MaximumNodeProviderRewardsE8s = maximumNodeProviderRewardsE8s;
		}

		public MonthlyNodeProviderRewards()
		{
		}
	}
}