using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class SetFirewallConfigPayload
	{
		[CandidName("ipv4_prefixes")]
		public List<string> Ipv4Prefixes { get; set; }

		[CandidName("firewall_config")]
		public string FirewallConfig { get; set; }

		[CandidName("ipv6_prefixes")]
		public List<string> Ipv6Prefixes { get; set; }

		public SetFirewallConfigPayload(List<string> ipv4Prefixes, string firewallConfig, List<string> ipv6Prefixes)
		{
			this.Ipv4Prefixes = ipv4Prefixes;
			this.FirewallConfig = firewallConfig;
			this.Ipv6Prefixes = ipv6Prefixes;
		}

		public SetFirewallConfigPayload()
		{
		}
	}
}