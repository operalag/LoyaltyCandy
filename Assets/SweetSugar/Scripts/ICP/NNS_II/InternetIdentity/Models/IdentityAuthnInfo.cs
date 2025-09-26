using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.InternetIdentity.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class IdentityAuthnInfo
	{
		[CandidName("authn_methods")]
		public List<AuthnMethod> AuthnMethods { get; set; }

		[CandidName("recovery_authn_methods")]
		public List<AuthnMethod> RecoveryAuthnMethods { get; set; }

		public IdentityAuthnInfo(List<AuthnMethod> authnMethods, List<AuthnMethod> recoveryAuthnMethods)
		{
			this.AuthnMethods = authnMethods;
			this.RecoveryAuthnMethods = recoveryAuthnMethods;
		}

		public IdentityAuthnInfo()
		{
		}
	}
}