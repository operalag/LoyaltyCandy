using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRoot.Models;
using System;

namespace LoyaltyCandy.NNSRoot.Models
{
	[Variant]
	public class UpdateCanisterSettingsResponse
	{
		[VariantTagProperty]
		public UpdateCanisterSettingsResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public UpdateCanisterSettingsResponse(UpdateCanisterSettingsResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected UpdateCanisterSettingsResponse()
		{
		}

		public static UpdateCanisterSettingsResponse Ok()
		{
			return new UpdateCanisterSettingsResponse(UpdateCanisterSettingsResponseTag.Ok, null);
		}

		public static UpdateCanisterSettingsResponse Err(UpdateCanisterSettingsError info)
		{
			return new UpdateCanisterSettingsResponse(UpdateCanisterSettingsResponseTag.Err, info);
		}

		public UpdateCanisterSettingsError AsErr()
		{
			this.ValidateTag(UpdateCanisterSettingsResponseTag.Err);
			return (UpdateCanisterSettingsError)this.Value!;
		}

		private void ValidateTag(UpdateCanisterSettingsResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum UpdateCanisterSettingsResponseTag
	{
		Ok,
		Err
	}
}