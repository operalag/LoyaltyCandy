using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class NodeProvidersMonthlyXdrRewards
	{
		[CandidName("rewards")]
		public Dictionary<string, ulong> Rewards { get; set; }

		[CandidName("registry_version")]
		public OptionalValue<ulong> RegistryVersion { get; set; }

		public NodeProvidersMonthlyXdrRewards(Dictionary<string, ulong> rewards, OptionalValue<ulong> registryVersion)
		{
			this.Rewards = rewards;
			this.RegistryVersion = registryVersion;
		}

		public NodeProvidersMonthlyXdrRewards()
		{
		}
	}
}