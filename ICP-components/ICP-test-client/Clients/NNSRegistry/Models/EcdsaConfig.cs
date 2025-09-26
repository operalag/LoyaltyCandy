using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class EcdsaConfig
	{
		[CandidName("quadruples_to_create_in_advance")]
		public uint QuadruplesToCreateInAdvance { get; set; }

		[CandidName("max_queue_size")]
		public OptionalValue<uint> MaxQueueSize { get; set; }

		[CandidName("key_ids")]
		public List<EcdsaKeyId> KeyIds { get; set; }

		[CandidName("signature_request_timeout_ns")]
		public OptionalValue<ulong> SignatureRequestTimeoutNs { get; set; }

		[CandidName("idkg_key_rotation_period_ms")]
		public OptionalValue<ulong> IdkgKeyRotationPeriodMs { get; set; }

		public EcdsaConfig(uint quadruplesToCreateInAdvance, OptionalValue<uint> maxQueueSize, List<EcdsaKeyId> keyIds, OptionalValue<ulong> signatureRequestTimeoutNs, OptionalValue<ulong> idkgKeyRotationPeriodMs)
		{
			this.QuadruplesToCreateInAdvance = quadruplesToCreateInAdvance;
			this.MaxQueueSize = maxQueueSize;
			this.KeyIds = keyIds;
			this.SignatureRequestTimeoutNs = signatureRequestTimeoutNs;
			this.IdkgKeyRotationPeriodMs = idkgKeyRotationPeriodMs;
		}

		public EcdsaConfig()
		{
		}
	}
}