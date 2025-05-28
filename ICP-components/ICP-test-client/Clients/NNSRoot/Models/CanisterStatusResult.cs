using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRoot.Models;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class CanisterStatusResult
	{
		[CandidName("status")]
		public CanisterStatusType Status { get; set; }

		[CandidName("memory_size")]
		public UnboundedUInt MemorySize { get; set; }

		[CandidName("cycles")]
		public UnboundedUInt Cycles { get; set; }

		[CandidName("settings")]
		public DefiniteCanisterSettings Settings { get; set; }

		[CandidName("idle_cycles_burned_per_day")]
		public OptionalValue<UnboundedUInt> IdleCyclesBurnedPerDay { get; set; }

		[CandidName("module_hash")]
		public OptionalValue<List<byte>> ModuleHash { get; set; }

		[CandidName("reserved_cycles")]
		public OptionalValue<UnboundedUInt> ReservedCycles { get; set; }

		[CandidName("query_stats")]
		public OptionalValue<QueryStats> QueryStats { get; set; }

		public CanisterStatusResult(CanisterStatusType status, UnboundedUInt memorySize, UnboundedUInt cycles, DefiniteCanisterSettings settings, OptionalValue<UnboundedUInt> idleCyclesBurnedPerDay, OptionalValue<List<byte>> moduleHash, OptionalValue<UnboundedUInt> reservedCycles, OptionalValue<QueryStats> queryStats)
		{
			this.Status = status;
			this.MemorySize = memorySize;
			this.Cycles = cycles;
			this.Settings = settings;
			this.IdleCyclesBurnedPerDay = idleCyclesBurnedPerDay;
			this.ModuleHash = moduleHash;
			this.ReservedCycles = reservedCycles;
			this.QueryStats = queryStats;
		}

		public CanisterStatusResult()
		{
		}
	}
}