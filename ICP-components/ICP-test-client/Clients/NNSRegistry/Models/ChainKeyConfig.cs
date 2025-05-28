using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class ChainKeyConfig
	{
		[CandidName("key_configs")]
		public List<KeyConfig> KeyConfigs { get; set; }

		[CandidName("signature_request_timeout_ns")]
		public OptionalValue<ulong> SignatureRequestTimeoutNs { get; set; }

		[CandidName("idkg_key_rotation_period_ms")]
		public OptionalValue<ulong> IdkgKeyRotationPeriodMs { get; set; }

		public ChainKeyConfig(List<KeyConfig> keyConfigs, OptionalValue<ulong> signatureRequestTimeoutNs, OptionalValue<ulong> idkgKeyRotationPeriodMs)
		{
			this.KeyConfigs = keyConfigs;
			this.SignatureRequestTimeoutNs = signatureRequestTimeoutNs;
			this.IdkgKeyRotationPeriodMs = idkgKeyRotationPeriodMs;
		}

		public ChainKeyConfig()
		{
		}
	}
}