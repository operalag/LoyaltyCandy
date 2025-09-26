using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class UpdateNodeDomainDirectlyResponse
	{
		[VariantTagProperty]
		public UpdateNodeDomainDirectlyResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public UpdateNodeDomainDirectlyResponse(UpdateNodeDomainDirectlyResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected UpdateNodeDomainDirectlyResponse()
		{
		}

		public static UpdateNodeDomainDirectlyResponse Ok()
		{
			return new UpdateNodeDomainDirectlyResponse(UpdateNodeDomainDirectlyResponseTag.Ok, null);
		}

		public static UpdateNodeDomainDirectlyResponse Err(string info)
		{
			return new UpdateNodeDomainDirectlyResponse(UpdateNodeDomainDirectlyResponseTag.Err, info);
		}

		public string AsErr()
		{
			this.ValidateTag(UpdateNodeDomainDirectlyResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(UpdateNodeDomainDirectlyResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum UpdateNodeDomainDirectlyResponseTag
	{
		Ok,
		Err
	}
}