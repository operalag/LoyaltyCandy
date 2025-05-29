using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class ArchiveOptions
	{
		[CandidName("trigger_threshold")]
		public ulong TriggerThreshold { get; set; }

		[CandidName("num_blocks_to_archive")]
		public ulong NumBlocksToArchive { get; set; }

		[CandidName("node_max_memory_size_bytes")]
		public OptionalValue<ulong> NodeMaxMemorySizeBytes { get; set; }

		[CandidName("max_message_size_bytes")]
		public OptionalValue<ulong> MaxMessageSizeBytes { get; set; }

		[CandidName("controller_id")]
		public Principal ControllerId { get; set; }

		[CandidName("more_controller_ids")]
		public OptionalValue<List<Principal>> MoreControllerIds { get; set; }

		[CandidName("cycles_for_archive_creation")]
		public OptionalValue<ulong> CyclesForArchiveCreation { get; set; }

		[CandidName("max_transactions_per_response")]
		public OptionalValue<ulong> MaxTransactionsPerResponse { get; set; }

		public ArchiveOptions(ulong triggerThreshold, ulong numBlocksToArchive, OptionalValue<ulong> nodeMaxMemorySizeBytes, OptionalValue<ulong> maxMessageSizeBytes, Principal controllerId, OptionalValue<List<Principal>> moreControllerIds, OptionalValue<ulong> cyclesForArchiveCreation, OptionalValue<ulong> maxTransactionsPerResponse)
		{
			this.TriggerThreshold = triggerThreshold;
			this.NumBlocksToArchive = numBlocksToArchive;
			this.NodeMaxMemorySizeBytes = nodeMaxMemorySizeBytes;
			this.MaxMessageSizeBytes = maxMessageSizeBytes;
			this.ControllerId = controllerId;
			this.MoreControllerIds = moreControllerIds;
			this.CyclesForArchiveCreation = cyclesForArchiveCreation;
			this.MaxTransactionsPerResponse = maxTransactionsPerResponse;
		}

		public ArchiveOptions()
		{
		}
	}
}