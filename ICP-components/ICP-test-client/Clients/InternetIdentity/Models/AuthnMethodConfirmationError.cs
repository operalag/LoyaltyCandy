using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AuthnMethodConfirmationError
	{
		[VariantTagProperty]
		public AuthnMethodConfirmationErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AuthnMethodConfirmationError(AuthnMethodConfirmationErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AuthnMethodConfirmationError()
		{
		}

		public static AuthnMethodConfirmationError WrongCode(AuthnMethodConfirmationError.WrongCodeInfo info)
		{
			return new AuthnMethodConfirmationError(AuthnMethodConfirmationErrorTag.WrongCode, info);
		}

		public static AuthnMethodConfirmationError RegistrationModeOff()
		{
			return new AuthnMethodConfirmationError(AuthnMethodConfirmationErrorTag.RegistrationModeOff, null);
		}

		public static AuthnMethodConfirmationError NoAuthnMethodToConfirm()
		{
			return new AuthnMethodConfirmationError(AuthnMethodConfirmationErrorTag.NoAuthnMethodToConfirm, null);
		}

		public AuthnMethodConfirmationError.WrongCodeInfo AsWrongCode()
		{
			this.ValidateTag(AuthnMethodConfirmationErrorTag.WrongCode);
			return (AuthnMethodConfirmationError.WrongCodeInfo)this.Value!;
		}

		private void ValidateTag(AuthnMethodConfirmationErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class WrongCodeInfo
		{
			[CandidName("retries_left")]
			public byte RetriesLeft { get; set; }

			public WrongCodeInfo(byte retriesLeft)
			{
				this.RetriesLeft = retriesLeft;
			}

			public WrongCodeInfo()
			{
			}
		}
	}

	public enum AuthnMethodConfirmationErrorTag
	{
		WrongCode,
		RegistrationModeOff,
		NoAuthnMethodToConfirm
	}
}