using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodeDirectlyPayload
	{
		[CandidName("idkg_dealing_encryption_pk")]
		public OptionalValue<List<byte>> IdkgDealingEncryptionPk { get; set; }

		public UpdateNodeDirectlyPayload(OptionalValue<List<byte>> idkgDealingEncryptionPk)
		{
			this.IdkgDealingEncryptionPk = idkgDealingEncryptionPk;
		}

		public UpdateNodeDirectlyPayload()
		{
		}
	}
}