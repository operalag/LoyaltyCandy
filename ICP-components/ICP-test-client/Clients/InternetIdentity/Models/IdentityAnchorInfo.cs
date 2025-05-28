using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class IdentityAnchorInfo
	{
		[CandidName("devices")]
		public List<DeviceWithUsage> Devices { get; set; }

		[CandidName("device_registration")]
		public OptionalValue<DeviceRegistrationInfo> DeviceRegistration { get; set; }

		public IdentityAnchorInfo(List<DeviceWithUsage> devices, OptionalValue<DeviceRegistrationInfo> deviceRegistration)
		{
			this.Devices = devices;
			this.DeviceRegistration = deviceRegistration;
		}

		public IdentityAnchorInfo()
		{
		}
	}
}