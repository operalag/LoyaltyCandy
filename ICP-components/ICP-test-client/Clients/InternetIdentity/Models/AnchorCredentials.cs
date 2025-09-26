using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.InternetIdentity.Models;
using PublicKey = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class AnchorCredentials
	{
		[CandidName("credentials")]
		public List<WebAuthnCredential> Credentials { get; set; }

		[CandidName("recovery_credentials")]
		public List<WebAuthnCredential> RecoveryCredentials { get; set; }

		[CandidName("recovery_phrases")]
		public AnchorCredentials.RecoveryPhrasesInfo RecoveryPhrases { get; set; }

		public AnchorCredentials(List<WebAuthnCredential> credentials, List<WebAuthnCredential> recoveryCredentials, AnchorCredentials.RecoveryPhrasesInfo recoveryPhrases)
		{
			this.Credentials = credentials;
			this.RecoveryCredentials = recoveryCredentials;
			this.RecoveryPhrases = recoveryPhrases;
		}

		public AnchorCredentials()
		{
		}

		public class RecoveryPhrasesInfo : List<PublicKey>
		{
			public RecoveryPhrasesInfo()
			{
			}
		}
	}
}