using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class KeyConfig
	{
		[CandidName("key_id")]
		public OptionalValue<MasterPublicKeyId> KeyId { get; set; }

		[CandidName("pre_signatures_to_create_in_advance")]
		public OptionalValue<uint> PreSignaturesToCreateInAdvance { get; set; }

		[CandidName("max_queue_size")]
		public OptionalValue<uint> MaxQueueSize { get; set; }

		public KeyConfig(OptionalValue<MasterPublicKeyId> keyId, OptionalValue<uint> preSignaturesToCreateInAdvance, OptionalValue<uint> maxQueueSize)
		{
			this.KeyId = keyId;
			this.PreSignaturesToCreateInAdvance = preSignaturesToCreateInAdvance;
			this.MaxQueueSize = maxQueueSize;
		}

		public KeyConfig()
		{
		}
	}
}