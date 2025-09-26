using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class EcdsaKeyRequest
	{
		[CandidName("key_id")]
		public EcdsaKeyId KeyId { get; set; }

		[CandidName("subnet_id")]
		public OptionalValue<Principal> SubnetId { get; set; }

		public EcdsaKeyRequest(EcdsaKeyId keyId, OptionalValue<Principal> subnetId)
		{
			this.KeyId = keyId;
			this.SubnetId = subnetId;
		}

		public EcdsaKeyRequest()
		{
		}
	}
}