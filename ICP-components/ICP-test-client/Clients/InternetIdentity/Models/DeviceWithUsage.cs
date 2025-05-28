using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using CredentialId = System.Collections.Generic.List<System.Byte>;
using DeviceKey = System.Collections.Generic.List<System.Byte>;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class DeviceWithUsage
	{
		[CandidName("pubkey")]
		public DeviceKey Pubkey { get; set; }

		[CandidName("alias")]
		public string Alias { get; set; }

		[CandidName("credential_id")]
		public DeviceWithUsage.CredentialIdInfo CredentialId { get; set; }

		[CandidName("purpose")]
		public Purpose Purpose { get; set; }

		[CandidName("key_type")]
		public KeyType KeyType { get; set; }

		[CandidName("protection")]
		public DeviceProtection Protection { get; set; }

		[CandidName("origin")]
		public OptionalValue<string> Origin { get; set; }

		[CandidName("last_usage")]
		public DeviceWithUsage.LastUsageInfo LastUsage { get; set; }

		[CandidName("metadata")]
		public OptionalValue<MetadataMap> Metadata { get; set; }

		public DeviceWithUsage(DeviceKey pubkey, string alias, DeviceWithUsage.CredentialIdInfo credentialId, Purpose purpose, KeyType keyType, DeviceProtection protection, OptionalValue<string> origin, DeviceWithUsage.LastUsageInfo lastUsage, OptionalValue<MetadataMap> metadata)
		{
			this.Pubkey = pubkey;
			this.Alias = alias;
			this.CredentialId = credentialId;
			this.Purpose = purpose;
			this.KeyType = keyType;
			this.Protection = protection;
			this.Origin = origin;
			this.LastUsage = lastUsage;
			this.Metadata = metadata;
		}

		public DeviceWithUsage()
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

		public class LastUsageInfo : OptionalValue<Timestamp>
		{
			public LastUsageInfo()
			{
			}

			public LastUsageInfo(Timestamp value) : base(value)
			{
			}
		}
	}
}