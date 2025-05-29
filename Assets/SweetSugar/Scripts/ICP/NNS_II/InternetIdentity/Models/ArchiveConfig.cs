using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class ArchiveConfig
	{
		[CandidName("module_hash")]
		public List<byte> ModuleHash { get; set; }

		[CandidName("entries_buffer_limit")]
		public ulong EntriesBufferLimit { get; set; }

		[CandidName("entries_fetch_limit")]
		public ushort EntriesFetchLimit { get; set; }

		[CandidName("polling_interval_ns")]
		public ulong PollingIntervalNs { get; set; }

		public ArchiveConfig(List<byte> moduleHash, ulong entriesBufferLimit, ushort entriesFetchLimit, ulong pollingIntervalNs)
		{
			this.ModuleHash = moduleHash;
			this.EntriesBufferLimit = entriesBufferLimit;
			this.EntriesFetchLimit = entriesFetchLimit;
			this.PollingIntervalNs = pollingIntervalNs;
		}

		public ArchiveConfig()
		{
		}
	}
}