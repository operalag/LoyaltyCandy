using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AuthnMethodMetadataReplaceError
	{
		[VariantTagProperty]
		public AuthnMethodMetadataReplaceErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AuthnMethodMetadataReplaceError(AuthnMethodMetadataReplaceErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AuthnMethodMetadataReplaceError()
		{
		}

		public static AuthnMethodMetadataReplaceError InvalidMetadata(string info)
		{
			return new AuthnMethodMetadataReplaceError(AuthnMethodMetadataReplaceErrorTag.InvalidMetadata, info);
		}

		public static AuthnMethodMetadataReplaceError AuthnMethodNotFound()
		{
			return new AuthnMethodMetadataReplaceError(AuthnMethodMetadataReplaceErrorTag.AuthnMethodNotFound, null);
		}

		public string AsInvalidMetadata()
		{
			this.ValidateTag(AuthnMethodMetadataReplaceErrorTag.InvalidMetadata);
			return (string)this.Value!;
		}

		private void ValidateTag(AuthnMethodMetadataReplaceErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum AuthnMethodMetadataReplaceErrorTag
	{
		InvalidMetadata,
		AuthnMethodNotFound
	}
}