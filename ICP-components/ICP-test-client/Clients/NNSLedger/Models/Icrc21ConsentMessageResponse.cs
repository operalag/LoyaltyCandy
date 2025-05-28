using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using System;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class Icrc21ConsentMessageResponse
	{
		[VariantTagProperty]
		public Icrc21ConsentMessageResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Icrc21ConsentMessageResponse(Icrc21ConsentMessageResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Icrc21ConsentMessageResponse()
		{
		}

		public static Icrc21ConsentMessageResponse Ok(Icrc21ConsentInfo info)
		{
			return new Icrc21ConsentMessageResponse(Icrc21ConsentMessageResponseTag.Ok, info);
		}

		public static Icrc21ConsentMessageResponse Err(Icrc21Error info)
		{
			return new Icrc21ConsentMessageResponse(Icrc21ConsentMessageResponseTag.Err, info);
		}

		public Icrc21ConsentInfo AsOk()
		{
			this.ValidateTag(Icrc21ConsentMessageResponseTag.Ok);
			return (Icrc21ConsentInfo)this.Value!;
		}

		public Icrc21Error AsErr()
		{
			this.ValidateTag(Icrc21ConsentMessageResponseTag.Err);
			return (Icrc21Error)this.Value!;
		}

		private void ValidateTag(Icrc21ConsentMessageResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum Icrc21ConsentMessageResponseTag
	{
		Ok,
		Err
	}
}