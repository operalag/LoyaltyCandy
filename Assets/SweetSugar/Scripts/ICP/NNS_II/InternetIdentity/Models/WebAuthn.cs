using EdjCase.ICP.Candid.Mapping;
using PublicKey = System.Collections.Generic.List<System.Byte>;
using CredentialId = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class WebAuthn
	{
		[CandidName("credential_id")]
		public CredentialId CredentialId { get; set; }

		[CandidName("pubkey")]
		public PublicKey Pubkey { get; set; }

		public WebAuthn(CredentialId credentialId, PublicKey pubkey)
		{
			this.CredentialId = credentialId;
			this.Pubkey = pubkey;
		}

		public WebAuthn()
		{
		}
	}
}