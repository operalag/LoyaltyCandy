using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class IdAliasCredentials
	{
		[CandidName("rp_id_alias_credential")]
		public SignedIdAlias RpIdAliasCredential { get; set; }

		[CandidName("issuer_id_alias_credential")]
		public SignedIdAlias IssuerIdAliasCredential { get; set; }

		public IdAliasCredentials(SignedIdAlias rpIdAliasCredential, SignedIdAlias issuerIdAliasCredential)
		{
			this.RpIdAliasCredential = rpIdAliasCredential;
			this.IssuerIdAliasCredential = issuerIdAliasCredential;
		}

		public IdAliasCredentials()
		{
		}
	}
}