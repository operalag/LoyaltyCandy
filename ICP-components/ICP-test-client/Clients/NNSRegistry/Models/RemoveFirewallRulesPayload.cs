using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class RemoveFirewallRulesPayload
	{
		[CandidName("expected_hash")]
		public string ExpectedHash { get; set; }

		[CandidName("scope")]
		public FirewallRulesScope Scope { get; set; }

		[CandidName("positions")]
		public List<int> Positions { get; set; }

		public RemoveFirewallRulesPayload(string expectedHash, FirewallRulesScope scope, List<int> positions)
		{
			this.ExpectedHash = expectedHash;
			this.Scope = scope;
			this.Positions = positions;
		}

		public RemoveFirewallRulesPayload()
		{
		}
	}
}