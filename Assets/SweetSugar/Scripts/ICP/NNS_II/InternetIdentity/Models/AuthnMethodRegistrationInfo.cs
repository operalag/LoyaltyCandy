using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.InternetIdentity.Models;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class AuthnMethodRegistrationInfo
	{
		[CandidName("authn_method")]
		public OptionalValue<AuthnMethodData> AuthnMethod { get; set; }

		[CandidName("expiration")]
		public Timestamp Expiration { get; set; }

		public AuthnMethodRegistrationInfo(OptionalValue<AuthnMethodData> authnMethod, Timestamp expiration)
		{
			this.AuthnMethod = authnMethod;
			this.Expiration = expiration;
		}

		public AuthnMethodRegistrationInfo()
		{
		}
	}
}