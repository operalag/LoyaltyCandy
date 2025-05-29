using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class IdentityInfoError
	{
		[VariantTagProperty]
		public IdentityInfoErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public IdentityInfoError(IdentityInfoErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected IdentityInfoError()
		{
		}

		public static IdentityInfoError Unauthorized(Principal info)
		{
			return new IdentityInfoError(IdentityInfoErrorTag.Unauthorized, info);
		}

		public static IdentityInfoError InternalCanisterError(string info)
		{
			return new IdentityInfoError(IdentityInfoErrorTag.InternalCanisterError, info);
		}

		public Principal AsUnauthorized()
		{
			this.ValidateTag(IdentityInfoErrorTag.Unauthorized);
			return (Principal)this.Value!;
		}

		public string AsInternalCanisterError()
		{
			this.ValidateTag(IdentityInfoErrorTag.InternalCanisterError);
			return (string)this.Value!;
		}

		private void ValidateTag(IdentityInfoErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum IdentityInfoErrorTag
	{
		Unauthorized,
		InternalCanisterError
	}
}