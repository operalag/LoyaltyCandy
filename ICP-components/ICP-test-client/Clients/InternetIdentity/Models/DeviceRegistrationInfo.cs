using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.InternetIdentity.Models;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class DeviceRegistrationInfo
	{
		[CandidName("tentative_device")]
		public OptionalValue<DeviceData> TentativeDevice { get; set; }

		[CandidName("expiration")]
		public Timestamp Expiration { get; set; }

		public DeviceRegistrationInfo(OptionalValue<DeviceData> tentativeDevice, Timestamp expiration)
		{
			this.TentativeDevice = tentativeDevice;
			this.Expiration = expiration;
		}

		public DeviceRegistrationInfo()
		{
		}
	}
}