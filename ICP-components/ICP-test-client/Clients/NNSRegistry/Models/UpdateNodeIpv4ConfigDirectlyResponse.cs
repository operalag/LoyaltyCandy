using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class UpdateNodeIpv4ConfigDirectlyResponse
	{
		[VariantTagProperty]
		public UpdateNodeIpv4ConfigDirectlyResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public UpdateNodeIpv4ConfigDirectlyResponse(UpdateNodeIpv4ConfigDirectlyResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected UpdateNodeIpv4ConfigDirectlyResponse()
		{
		}

		public static UpdateNodeIpv4ConfigDirectlyResponse Ok()
		{
			return new UpdateNodeIpv4ConfigDirectlyResponse(UpdateNodeIpv4ConfigDirectlyResponseTag.Ok, null);
		}

		public static UpdateNodeIpv4ConfigDirectlyResponse Err(string info)
		{
			return new UpdateNodeIpv4ConfigDirectlyResponse(UpdateNodeIpv4ConfigDirectlyResponseTag.Err, info);
		}

		public string AsErr()
		{
			this.ValidateTag(UpdateNodeIpv4ConfigDirectlyResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(UpdateNodeIpv4ConfigDirectlyResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum UpdateNodeIpv4ConfigDirectlyResponseTag
	{
		Ok,
		Err
	}
}