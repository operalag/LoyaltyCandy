using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class PrepareIdAliasError
	{
		[VariantTagProperty]
		public PrepareIdAliasErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public PrepareIdAliasError(PrepareIdAliasErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected PrepareIdAliasError()
		{
		}

		public static PrepareIdAliasError Unauthorized(Principal info)
		{
			return new PrepareIdAliasError(PrepareIdAliasErrorTag.Unauthorized, info);
		}

		public static PrepareIdAliasError InternalCanisterError(string info)
		{
			return new PrepareIdAliasError(PrepareIdAliasErrorTag.InternalCanisterError, info);
		}

		public Principal AsUnauthorized()
		{
			this.ValidateTag(PrepareIdAliasErrorTag.Unauthorized);
			return (Principal)this.Value!;
		}

		public string AsInternalCanisterError()
		{
			this.ValidateTag(PrepareIdAliasErrorTag.InternalCanisterError);
			return (string)this.Value!;
		}

		private void ValidateTag(PrepareIdAliasErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum PrepareIdAliasErrorTag
	{
		Unauthorized,
		InternalCanisterError
	}
}