using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.InternetIdentity.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class ArchiveInfo
	{
		[CandidName("archive_canister")]
		public OptionalValue<Principal> ArchiveCanister { get; set; }

		[CandidName("archive_config")]
		public OptionalValue<ArchiveConfig> ArchiveConfig { get; set; }

		public ArchiveInfo(OptionalValue<Principal> archiveCanister, OptionalValue<ArchiveConfig> archiveConfig)
		{
			this.ArchiveCanister = archiveCanister;
			this.ArchiveConfig = archiveConfig;
		}

		public ArchiveInfo()
		{
		}
	}
}