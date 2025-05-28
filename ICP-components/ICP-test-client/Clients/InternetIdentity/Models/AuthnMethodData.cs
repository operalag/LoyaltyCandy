using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class AuthnMethodData
	{
		[CandidName("authn_method")]
		public AuthnMethod AuthnMethod { get; set; }

		[CandidName("security_settings")]
		public AuthnMethodSecuritySettings SecuritySettings { get; set; }

		[CandidName("metadata")]
		public MetadataMapV2 Metadata { get; set; }

		[CandidName("last_authentication")]
		public AuthnMethodData.LastAuthenticationInfo LastAuthentication { get; set; }

		public AuthnMethodData(AuthnMethod authnMethod, AuthnMethodSecuritySettings securitySettings, MetadataMapV2 metadata, AuthnMethodData.LastAuthenticationInfo lastAuthentication)
		{
			this.AuthnMethod = authnMethod;
			this.SecuritySettings = securitySettings;
			this.Metadata = metadata;
			this.LastAuthentication = lastAuthentication;
		}

		public AuthnMethodData()
		{
		}

		public class LastAuthenticationInfo : OptionalValue<Timestamp>
		{
			public LastAuthenticationInfo()
			{
			}

			public LastAuthenticationInfo(Timestamp value) : base(value)
			{
			}
		}
	}
}