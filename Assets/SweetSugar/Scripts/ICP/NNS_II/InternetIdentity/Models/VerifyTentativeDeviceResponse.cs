using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class VerifyTentativeDeviceResponse
	{
		[VariantTagProperty]
		public VerifyTentativeDeviceResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public VerifyTentativeDeviceResponse(VerifyTentativeDeviceResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected VerifyTentativeDeviceResponse()
		{
		}

		public static VerifyTentativeDeviceResponse Verified()
		{
			return new VerifyTentativeDeviceResponse(VerifyTentativeDeviceResponseTag.Verified, null);
		}

		public static VerifyTentativeDeviceResponse WrongCode(VerifyTentativeDeviceResponse.WrongCodeInfo info)
		{
			return new VerifyTentativeDeviceResponse(VerifyTentativeDeviceResponseTag.WrongCode, info);
		}

		public static VerifyTentativeDeviceResponse DeviceRegistrationModeOff()
		{
			return new VerifyTentativeDeviceResponse(VerifyTentativeDeviceResponseTag.DeviceRegistrationModeOff, null);
		}

		public static VerifyTentativeDeviceResponse NoDeviceToVerify()
		{
			return new VerifyTentativeDeviceResponse(VerifyTentativeDeviceResponseTag.NoDeviceToVerify, null);
		}

		public VerifyTentativeDeviceResponse.WrongCodeInfo AsWrongCode()
		{
			this.ValidateTag(VerifyTentativeDeviceResponseTag.WrongCode);
			return (VerifyTentativeDeviceResponse.WrongCodeInfo)this.Value!;
		}

		private void ValidateTag(VerifyTentativeDeviceResponseTag tag)
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

	public enum VerifyTentativeDeviceResponseTag
	{
		[CandidName("verified")]
		Verified,
		[CandidName("wrong_code")]
		WrongCode,
		[CandidName("device_registration_mode_off")]
		DeviceRegistrationModeOff,
		[CandidName("no_device_to_verify")]
		NoDeviceToVerify
	}
}