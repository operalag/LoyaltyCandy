using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class GetNodeProvidersMonthlyXdrRewardsResponse
	{
		[VariantTagProperty]
		public GetNodeProvidersMonthlyXdrRewardsResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetNodeProvidersMonthlyXdrRewardsResponse(GetNodeProvidersMonthlyXdrRewardsResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetNodeProvidersMonthlyXdrRewardsResponse()
		{
		}

		public static GetNodeProvidersMonthlyXdrRewardsResponse Ok(NodeProvidersMonthlyXdrRewards info)
		{
			return new GetNodeProvidersMonthlyXdrRewardsResponse(GetNodeProvidersMonthlyXdrRewardsResponseTag.Ok, info);
		}

		public static GetNodeProvidersMonthlyXdrRewardsResponse Err(string info)
		{
			return new GetNodeProvidersMonthlyXdrRewardsResponse(GetNodeProvidersMonthlyXdrRewardsResponseTag.Err, info);
		}

		public NodeProvidersMonthlyXdrRewards AsOk()
		{
			this.ValidateTag(GetNodeProvidersMonthlyXdrRewardsResponseTag.Ok);
			return (NodeProvidersMonthlyXdrRewards)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(GetNodeProvidersMonthlyXdrRewardsResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(GetNodeProvidersMonthlyXdrRewardsResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetNodeProvidersMonthlyXdrRewardsResponseTag
	{
		Ok,
		Err
	}
}