using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class IdentityInfo
	{
		[CandidName("authn_methods")]
		public List<AuthnMethodData> AuthnMethods { get; set; }

		[CandidName("authn_method_registration")]
		public OptionalValue<AuthnMethodRegistrationInfo> AuthnMethodRegistration { get; set; }

		[CandidName("metadata")]
		public MetadataMapV2 Metadata { get; set; }

		public IdentityInfo(List<AuthnMethodData> authnMethods, OptionalValue<AuthnMethodRegistrationInfo> authnMethodRegistration, MetadataMapV2 metadata)
		{
			this.AuthnMethods = authnMethods;
			this.AuthnMethodRegistration = authnMethodRegistration;
			this.Metadata = metadata;
		}

		public IdentityInfo()
		{
		}
	}
}