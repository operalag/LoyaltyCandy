using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AuthnMethodAddError
	{
		[VariantTagProperty]
		public AuthnMethodAddErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AuthnMethodAddError(AuthnMethodAddErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AuthnMethodAddError()
		{
		}

		public static AuthnMethodAddError InvalidMetadata(string info)
		{
			return new AuthnMethodAddError(AuthnMethodAddErrorTag.InvalidMetadata, info);
		}

		public string AsInvalidMetadata()
		{
			this.ValidateTag(AuthnMethodAddErrorTag.InvalidMetadata);
			return (string)this.Value!;
		}

		private void ValidateTag(AuthnMethodAddErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum AuthnMethodAddErrorTag
	{
		InvalidMetadata
	}
}