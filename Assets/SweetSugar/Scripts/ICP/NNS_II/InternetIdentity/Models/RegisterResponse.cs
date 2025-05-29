using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;
using UserNumber = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class RegisterResponse
	{
		[VariantTagProperty]
		public RegisterResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public RegisterResponse(RegisterResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected RegisterResponse()
		{
		}

		public static RegisterResponse Registered(RegisterResponse.RegisteredInfo info)
		{
			return new RegisterResponse(RegisterResponseTag.Registered, info);
		}

		public static RegisterResponse CanisterFull()
		{
			return new RegisterResponse(RegisterResponseTag.CanisterFull, null);
		}

		public static RegisterResponse BadChallenge()
		{
			return new RegisterResponse(RegisterResponseTag.BadChallenge, null);
		}

		public RegisterResponse.RegisteredInfo AsRegistered()
		{
			this.ValidateTag(RegisterResponseTag.Registered);
			return (RegisterResponse.RegisteredInfo)this.Value!;
		}

		private void ValidateTag(RegisterResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class RegisteredInfo
		{
			[CandidName("user_number")]
			public UserNumber UserNumber { get; set; }

			public RegisteredInfo(UserNumber userNumber)
			{
				this.UserNumber = userNumber;
			}

			public RegisteredInfo()
			{
			}
		}
	}

	public enum RegisterResponseTag
	{
		[CandidName("registered")]
		Registered,
		[CandidName("canister_full")]
		CanisterFull,
		[CandidName("bad_challenge")]
		BadChallenge
	}
}