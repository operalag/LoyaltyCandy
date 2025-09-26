using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class FirewallRule
	{
		[CandidName("ipv4_prefixes")]
		public List<string> Ipv4Prefixes { get; set; }

		[CandidName("direction")]
		public OptionalValue<int> Direction { get; set; }

		[CandidName("action")]
		public int Action { get; set; }

		[CandidName("user")]
		public OptionalValue<string> User { get; set; }

		[CandidName("comment")]
		public string Comment { get; set; }

		[CandidName("ipv6_prefixes")]
		public List<string> Ipv6Prefixes { get; set; }

		[CandidName("ports")]
		public List<uint> Ports { get; set; }

		public FirewallRule(List<string> ipv4Prefixes, OptionalValue<int> direction, int action, OptionalValue<string> user, string comment, List<string> ipv6Prefixes, List<uint> ports)
		{
			this.Ipv4Prefixes = ipv4Prefixes;
			this.Direction = direction;
			this.Action = action;
			this.User = user;
			this.Comment = comment;
			this.Ipv6Prefixes = ipv6Prefixes;
			this.Ports = ports;
		}

		public FirewallRule()
		{
		}
	}
}