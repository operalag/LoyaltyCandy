using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class IdentityRegisterError
	{
		[VariantTagProperty]
		public IdentityRegisterErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public IdentityRegisterError(IdentityRegisterErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected IdentityRegisterError()
		{
		}

		public static IdentityRegisterError CanisterFull()
		{
			return new IdentityRegisterError(IdentityRegisterErrorTag.CanisterFull, null);
		}

		public static IdentityRegisterError BadCaptcha()
		{
			return new IdentityRegisterError(IdentityRegisterErrorTag.BadCaptcha, null);
		}

		public static IdentityRegisterError InvalidMetadata(string info)
		{
			return new IdentityRegisterError(IdentityRegisterErrorTag.InvalidMetadata, info);
		}

		public string AsInvalidMetadata()
		{
			this.ValidateTag(IdentityRegisterErrorTag.InvalidMetadata);
			return (string)this.Value!;
		}

		private void ValidateTag(IdentityRegisterErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum IdentityRegisterErrorTag
	{
		CanisterFull,
		BadCaptcha,
		InvalidMetadata
	}
}