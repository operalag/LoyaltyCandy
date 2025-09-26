using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AuthnMethod
	{
		[VariantTagProperty]
		public AuthnMethodTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AuthnMethod(AuthnMethodTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AuthnMethod()
		{
		}

		public static AuthnMethod WebAuthn(WebAuthn info)
		{
			return new AuthnMethod(AuthnMethodTag.WebAuthn, info);
		}

		public static AuthnMethod PubKey(PublicKeyAuthn info)
		{
			return new AuthnMethod(AuthnMethodTag.PubKey, info);
		}

		public WebAuthn AsWebAuthn()
		{
			this.ValidateTag(AuthnMethodTag.WebAuthn);
			return (WebAuthn)this.Value!;
		}

		public PublicKeyAuthn AsPubKey()
		{
			this.ValidateTag(AuthnMethodTag.PubKey);
			return (PublicKeyAuthn)this.Value!;
		}

		private void ValidateTag(AuthnMethodTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum AuthnMethodTag
	{
		WebAuthn,
		PubKey
	}
}