using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class AddTentativeDeviceResponse
	{
		[VariantTagProperty]
		public AddTentativeDeviceResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public AddTentativeDeviceResponse(AddTentativeDeviceResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected AddTentativeDeviceResponse()
		{
		}

		public static AddTentativeDeviceResponse AddedTentatively(AddTentativeDeviceResponse.AddedTentativelyInfo info)
		{
			return new AddTentativeDeviceResponse(AddTentativeDeviceResponseTag.AddedTentatively, info);
		}

		public static AddTentativeDeviceResponse DeviceRegistrationModeOff()
		{
			return new AddTentativeDeviceResponse(AddTentativeDeviceResponseTag.DeviceRegistrationModeOff, null);
		}

		public static AddTentativeDeviceResponse AnotherDeviceTentativelyAdded()
		{
			return new AddTentativeDeviceResponse(AddTentativeDeviceResponseTag.AnotherDeviceTentativelyAdded, null);
		}

		public AddTentativeDeviceResponse.AddedTentativelyInfo AsAddedTentatively()
		{
			this.ValidateTag(AddTentativeDeviceResponseTag.AddedTentatively);
			return (AddTentativeDeviceResponse.AddedTentativelyInfo)this.Value!;
		}

		private void ValidateTag(AddTentativeDeviceResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class AddedTentativelyInfo
		{
			[CandidName("verification_code")]
			public string VerificationCode { get; set; }

			[CandidName("device_registration_timeout")]
			public Timestamp DeviceRegistrationTimeout { get; set; }

			public AddedTentativelyInfo(string verificationCode, Timestamp deviceRegistrationTimeout)
			{
				this.VerificationCode = verificationCode;
				this.DeviceRegistrationTimeout = deviceRegistrationTimeout;
			}

			public AddedTentativelyInfo()
			{
			}
		}
	}

	public enum AddTentativeDeviceResponseTag
	{
		[CandidName("added_tentatively")]
		AddedTentatively,
		[CandidName("device_registration_mode_off")]
		DeviceRegistrationModeOff,
		[CandidName("another_device_tentatively_added")]
		AnotherDeviceTentativelyAdded
	}
}