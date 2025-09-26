using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateFirewallRulesPayload
	{
		[CandidName("expected_hash")]
		public string ExpectedHash { get; set; }

		[CandidName("scope")]
		public FirewallRulesScope Scope { get; set; }

		[CandidName("positions")]
		public List<int> Positions { get; set; }

		[CandidName("rules")]
		public List<FirewallRule> Rules { get; set; }

		public UpdateFirewallRulesPayload(string expectedHash, FirewallRulesScope scope, List<int> positions, List<FirewallRule> rules)
		{
			this.ExpectedHash = expectedHash;
			this.Scope = scope;
			this.Positions = positions;
			this.Rules = rules;
		}

		public UpdateFirewallRulesPayload()
		{
		}
	}
}