using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSDapp.Models;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class Stats
	{
		[CandidName("accounts_count")]
		public ulong AccountsCount { get; set; }

		[CandidName("sub_accounts_count")]
		public ulong SubAccountsCount { get; set; }

		[CandidName("hardware_wallet_accounts_count")]
		public ulong HardwareWalletAccountsCount { get; set; }

		[CandidName("block_height_synced_up_to")]
		public OptionalValue<ulong> BlockHeightSyncedUpTo { get; set; }

		[CandidName("seconds_since_last_ledger_sync")]
		public ulong SecondsSinceLastLedgerSync { get; set; }

		[CandidName("neurons_created_count")]
		public ulong NeuronsCreatedCount { get; set; }

		[CandidName("neurons_topped_up_count")]
		public ulong NeuronsToppedUpCount { get; set; }

		[CandidName("transactions_to_process_queue_length")]
		public uint TransactionsToProcessQueueLength { get; set; }

		[CandidName("performance_counts")]
		public List<PerformanceCount> PerformanceCounts { get; set; }

		[CandidName("stable_memory_size_bytes")]
		public OptionalValue<ulong> StableMemorySizeBytes { get; set; }

		[CandidName("wasm_memory_size_bytes")]
		public OptionalValue<ulong> WasmMemorySizeBytes { get; set; }

		[CandidName("schema")]
		public OptionalValue<uint> Schema { get; set; }

		[CandidName("migration_countdown")]
		public OptionalValue<uint> MigrationCountdown { get; set; }

		[CandidName("accounts_db_stats_recomputed_on_upgrade")]
		public OptionalValue<bool> AccountsDbStatsRecomputedOnUpgrade { get; set; }

		public Stats(ulong accountsCount, ulong subAccountsCount, ulong hardwareWalletAccountsCount, OptionalValue<ulong> blockHeightSyncedUpTo, ulong secondsSinceLastLedgerSync, ulong neuronsCreatedCount, ulong neuronsToppedUpCount, uint transactionsToProcessQueueLength, List<PerformanceCount> performanceCounts, OptionalValue<ulong> stableMemorySizeBytes, OptionalValue<ulong> wasmMemorySizeBytes, OptionalValue<uint> schema, OptionalValue<uint> migrationCountdown, OptionalValue<bool> accountsDbStatsRecomputedOnUpgrade)
		{
			this.AccountsCount = accountsCount;
			this.SubAccountsCount = subAccountsCount;
			this.HardwareWalletAccountsCount = hardwareWalletAccountsCount;
			this.BlockHeightSyncedUpTo = blockHeightSyncedUpTo;
			this.SecondsSinceLastLedgerSync = secondsSinceLastLedgerSync;
			this.NeuronsCreatedCount = neuronsCreatedCount;
			this.NeuronsToppedUpCount = neuronsToppedUpCount;
			this.TransactionsToProcessQueueLength = transactionsToProcessQueueLength;
			this.PerformanceCounts = performanceCounts;
			this.StableMemorySizeBytes = stableMemorySizeBytes;
			this.WasmMemorySizeBytes = wasmMemorySizeBytes;
			this.Schema = schema;
			this.MigrationCountdown = migrationCountdown;
			this.AccountsDbStatsRecomputedOnUpgrade = accountsDbStatsRecomputedOnUpgrade;
		}

		public Stats()
		{
		}
	}
}