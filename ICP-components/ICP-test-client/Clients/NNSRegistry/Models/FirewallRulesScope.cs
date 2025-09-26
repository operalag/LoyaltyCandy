using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class FirewallRulesScope
	{
		[VariantTagProperty]
		public FirewallRulesScopeTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public FirewallRulesScope(FirewallRulesScopeTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected FirewallRulesScope()
		{
		}

		public static FirewallRulesScope Node(Principal info)
		{
			return new FirewallRulesScope(FirewallRulesScopeTag.Node, info);
		}

		public static FirewallRulesScope ReplicaNodes()
		{
			return new FirewallRulesScope(FirewallRulesScopeTag.ReplicaNodes, null);
		}

		public static FirewallRulesScope ApiBoundaryNodes()
		{
			return new FirewallRulesScope(FirewallRulesScopeTag.ApiBoundaryNodes, null);
		}

		public static FirewallRulesScope Subnet(Principal info)
		{
			return new FirewallRulesScope(FirewallRulesScopeTag.Subnet, info);
		}

		public static FirewallRulesScope Global()
		{
			return new FirewallRulesScope(FirewallRulesScopeTag.Global, null);
		}

		public Principal AsNode()
		{
			this.ValidateTag(FirewallRulesScopeTag.Node);
			return (Principal)this.Value!;
		}

		public Principal AsSubnet()
		{
			this.ValidateTag(FirewallRulesScopeTag.Subnet);
			return (Principal)this.Value!;
		}

		private void ValidateTag(FirewallRulesScopeTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum FirewallRulesScopeTag
	{
		Node,
		ReplicaNodes,
		ApiBoundaryNodes,
		Subnet,
		Global
	}
}