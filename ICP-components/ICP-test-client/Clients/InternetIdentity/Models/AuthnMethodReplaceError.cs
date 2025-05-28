using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AuthnMethodReplaceError
	{
		[VariantTagProperty]
		public AuthnMethodReplaceErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AuthnMethodReplaceError(AuthnMethodReplaceErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AuthnMethodReplaceError()
		{
		}

		public static AuthnMethodReplaceError InvalidMetadata(string info)
		{
			return new AuthnMethodReplaceError(AuthnMethodReplaceErrorTag.InvalidMetadata, info);
		}

		public static AuthnMethodReplaceError AuthnMethodNotFound()
		{
			return new AuthnMethodReplaceError(AuthnMethodReplaceErrorTag.AuthnMethodNotFound, null);
		}

		public string AsInvalidMetadata()
		{
			this.ValidateTag(AuthnMethodReplaceErrorTag.InvalidMetadata);
			return (string)this.Value!;
		}

		private void ValidateTag(AuthnMethodReplaceErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum AuthnMethodReplaceErrorTag
	{
		InvalidMetadata,
		AuthnMethodNotFound
	}
}