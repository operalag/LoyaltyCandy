using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class AuthnMethodSecuritySettings
	{
		[CandidName("protection")]
		public AuthnMethodProtection Protection { get; set; }

		[CandidName("purpose")]
		public AuthnMethodPurpose Purpose { get; set; }

		public AuthnMethodSecuritySettings(AuthnMethodProtection protection, AuthnMethodPurpose purpose)
		{
			this.Protection = protection;
			this.Purpose = purpose;
		}

		public AuthnMethodSecuritySettings()
		{
		}
	}
}