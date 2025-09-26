using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using CredentialId = System.Collections.Generic.List<System.Byte>;
using DeviceKey = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class DeviceData
	{
		[CandidName("pubkey")]
		public DeviceKey Pubkey { get; set; }

		[CandidName("alias")]
		public string Alias { get; set; }

		[CandidName("credential_id")]
		public DeviceData.CredentialIdInfo CredentialId { get; set; }

		[CandidName("purpose")]
		public Purpose Purpose { get; set; }

		[CandidName("key_type")]
		public KeyType KeyType { get; set; }

		[CandidName("protection")]
		public DeviceProtection Protection { get; set; }

		[CandidName("origin")]
		public OptionalValue<string> Origin { get; set; }

		[CandidName("metadata")]
		public OptionalValue<MetadataMap> Metadata { get; set; }

		public DeviceData(DeviceKey pubkey, string alias, DeviceData.CredentialIdInfo credentialId, Purpose purpose, KeyType keyType, DeviceProtection protection, OptionalValue<string> origin, OptionalValue<MetadataMap> metadata)
		{
			this.Pubkey = pubkey;
			this.Alias = alias;
			this.CredentialId = credentialId;
			this.Purpose = purpose;
			this.KeyType = keyType;
			this.Protection = protection;
			this.Origin = origin;
			this.Metadata = metadata;
		}

		public DeviceData()
		{
		}

		public class CredentialIdInfo : OptionalValue<CredentialId>
		{
			public CredentialIdInfo()
			{
			}

			public CredentialIdInfo(CredentialId value) : base(value)
			{
			}
		}
	}
}