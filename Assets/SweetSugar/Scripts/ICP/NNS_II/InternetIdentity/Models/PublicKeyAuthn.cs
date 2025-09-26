using EdjCase.ICP.Candid.Mapping;
using PublicKey = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class PublicKeyAuthn
	{
		[CandidName("pubkey")]
		public PublicKey Pubkey { get; set; }

		public PublicKeyAuthn(PublicKey pubkey)
		{
			this.Pubkey = pubkey;
		}

		public PublicKeyAuthn()
		{
		}
	}
}