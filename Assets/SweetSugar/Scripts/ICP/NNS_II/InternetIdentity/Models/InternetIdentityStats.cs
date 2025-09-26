using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class InternetIdentityStats
	{
		[CandidName("users_registered")]
		public ulong UsersRegistered { get; set; }

		[CandidName("storage_layout_version")]
		public byte StorageLayoutVersion { get; set; }

		[CandidName("assigned_user_number_range")]
		public (ulong, ulong) AssignedUserNumberRange { get; set; }

		[CandidName("archive_info")]
		public ArchiveInfo ArchiveInfo { get; set; }

		[CandidName("canister_creation_cycles_cost")]
		public ulong CanisterCreationCyclesCost { get; set; }

		[CandidName("event_aggregations")]
		public Dictionary<string, Dictionary<string, ulong>> EventAggregations { get; set; }

		public InternetIdentityStats(ulong usersRegistered, byte storageLayoutVersion, (ulong, ulong) assignedUserNumberRange, ArchiveInfo archiveInfo, ulong canisterCreationCyclesCost, Dictionary<string, Dictionary<string, ulong>> eventAggregations)
		{
			this.UsersRegistered = usersRegistered;
			this.StorageLayoutVersion = storageLayoutVersion;
			this.AssignedUserNumberRange = assignedUserNumberRange;
			this.ArchiveInfo = archiveInfo;
			this.CanisterCreationCyclesCost = canisterCreationCyclesCost;
			this.EventAggregations = eventAggregations;
		}

		public InternetIdentityStats()
		{
		}
	}
}