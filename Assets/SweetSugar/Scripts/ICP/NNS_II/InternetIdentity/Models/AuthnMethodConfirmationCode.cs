using EdjCase.ICP.Candid.Mapping;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class AuthnMethodConfirmationCode
	{
		[CandidName("confirmation_code")]
		public string ConfirmationCode { get; set; }

		[CandidName("expiration")]
		public Timestamp Expiration { get; set; }

		public AuthnMethodConfirmationCode(string confirmationCode, Timestamp expiration)
		{
			this.ConfirmationCode = confirmationCode;
			this.Expiration = expiration;
		}

		public AuthnMethodConfirmationCode()
		{
		}
	}
}