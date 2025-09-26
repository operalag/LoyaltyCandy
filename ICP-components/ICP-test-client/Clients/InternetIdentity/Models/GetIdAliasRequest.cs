using EdjCase.ICP.Candid.Mapping;
using FrontendHostname = System.String;
using IdentityNumber = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class GetIdAliasRequest
	{
		[CandidName("rp_id_alias_jwt")]
		public string RpIdAliasJwt { get; set; }

		[CandidName("issuer")]
		public FrontendHostname Issuer { get; set; }

		[CandidName("issuer_id_alias_jwt")]
		public string IssuerIdAliasJwt { get; set; }

		[CandidName("relying_party")]
		public FrontendHostname RelyingParty { get; set; }

		[CandidName("identity_number")]
		public IdentityNumber IdentityNumber { get; set; }

		public GetIdAliasRequest(string rpIdAliasJwt, FrontendHostname issuer, string issuerIdAliasJwt, FrontendHostname relyingParty, IdentityNumber identityNumber)
		{
			this.RpIdAliasJwt = rpIdAliasJwt;
			this.Issuer = issuer;
			this.IssuerIdAliasJwt = issuerIdAliasJwt;
			this.RelyingParty = relyingParty;
			this.IdentityNumber = identityNumber;
		}

		public GetIdAliasRequest()
		{
		}
	}
}