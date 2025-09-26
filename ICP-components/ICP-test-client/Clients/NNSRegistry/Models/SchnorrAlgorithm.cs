using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public enum SchnorrAlgorithm
	{
		[CandidName("ed25519")]
		Ed25519,
		[CandidName("bip340secp256k1")]
		Bip340secp256k1
	}
}