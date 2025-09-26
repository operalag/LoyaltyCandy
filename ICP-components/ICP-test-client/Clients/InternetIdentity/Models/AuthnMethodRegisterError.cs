using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AuthnMethodRegisterError
	{
		[VariantTagProperty]
		public AuthnMethodRegisterErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AuthnMethodRegisterError(AuthnMethodRegisterErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AuthnMethodRegisterError()
		{
		}

		public static AuthnMethodRegisterError RegistrationModeOff()
		{
			return new AuthnMethodRegisterError(AuthnMethodRegisterErrorTag.RegistrationModeOff, null);
		}

		public static AuthnMethodRegisterError RegistrationAlreadyInProgress()
		{
			return new AuthnMethodRegisterError(AuthnMethodRegisterErrorTag.RegistrationAlreadyInProgress, null);
		}

		public static AuthnMethodRegisterError InvalidMetadata(string info)
		{
			return new AuthnMethodRegisterError(AuthnMethodRegisterErrorTag.InvalidMetadata, info);
		}

		public string AsInvalidMetadata()
		{
			this.ValidateTag(AuthnMethodRegisterErrorTag.InvalidMetadata);
			return (string)this.Value!;
		}

		private void ValidateTag(AuthnMethodRegisterErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum AuthnMethodRegisterErrorTag
	{
		RegistrationModeOff,
		RegistrationAlreadyInProgress,
		InvalidMetadata
	}
}