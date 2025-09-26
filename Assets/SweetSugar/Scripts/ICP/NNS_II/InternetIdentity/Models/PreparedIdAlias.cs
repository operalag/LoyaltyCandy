using EdjCase.ICP.Candid.Mapping;
using PublicKey = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class PreparedIdAlias
	{
		[CandidName("rp_id_alias_jwt")]
		public string RpIdAliasJwt { get; set; }

		[CandidName("issuer_id_alias_jwt")]
		public string IssuerIdAliasJwt { get; set; }

		[CandidName("canister_sig_pk_der")]
		public PublicKey CanisterSigPkDer { get; set; }

		public PreparedIdAlias(string rpIdAliasJwt, string issuerIdAliasJwt, PublicKey canisterSigPkDer)
		{
			this.RpIdAliasJwt = rpIdAliasJwt;
			this.IssuerIdAliasJwt = issuerIdAliasJwt;
			this.CanisterSigPkDer = canisterSigPkDer;
		}

		public PreparedIdAlias()
		{
		}
	}
}