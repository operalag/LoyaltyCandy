using EdjCase.ICP.Candid.Mapping;
using FrontendHostname = System.String;
using IdentityNumber = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class PrepareIdAliasRequest
	{
		[CandidName("issuer")]
		public FrontendHostname Issuer { get; set; }

		[CandidName("relying_party")]
		public FrontendHostname RelyingParty { get; set; }

		[CandidName("identity_number")]
		public IdentityNumber IdentityNumber { get; set; }

		public PrepareIdAliasRequest(FrontendHostname issuer, FrontendHostname relyingParty, IdentityNumber identityNumber)
		{
			this.Issuer = issuer;
			this.RelyingParty = relyingParty;
			this.IdentityNumber = identityNumber;
		}

		public PrepareIdAliasRequest()
		{
		}
	}
}