using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class KeyConfigRequest
	{
		[CandidName("key_config")]
		public OptionalValue<KeyConfig> KeyConfig { get; set; }

		[CandidName("subnet_id")]
		public OptionalValue<Principal> SubnetId { get; set; }

		public KeyConfigRequest(OptionalValue<KeyConfig> keyConfig, OptionalValue<Principal> subnetId)
		{
			this.KeyConfig = keyConfig;
			this.SubnetId = subnetId;
		}

		public KeyConfigRequest()
		{
		}
	}
}