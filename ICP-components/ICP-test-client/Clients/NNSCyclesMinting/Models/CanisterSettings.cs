using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSCyclesMinting.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class CanisterSettings
	{
		[CandidName("controllers")]
		public OptionalValue<List<Principal>> Controllers { get; set; }

		[CandidName("compute_allocation")]
		public OptionalValue<UnboundedUInt> ComputeAllocation { get; set; }

		[CandidName("memory_allocation")]
		public OptionalValue<UnboundedUInt> MemoryAllocation { get; set; }

		[CandidName("freezing_threshold")]
		public OptionalValue<UnboundedUInt> FreezingThreshold { get; set; }

		[CandidName("reserved_cycles_limit")]
		public OptionalValue<UnboundedUInt> ReservedCyclesLimit { get; set; }

		[CandidName("log_visibility")]
		public OptionalValue<LogVisibility> LogVisibility { get; set; }

		[CandidName("wasm_memory_limit")]
		public OptionalValue<UnboundedUInt> WasmMemoryLimit { get; set; }

		[CandidName("wasm_memory_threshold")]
		public OptionalValue<UnboundedUInt> WasmMemoryThreshold { get; set; }

		public CanisterSettings(OptionalValue<List<Principal>> controllers, OptionalValue<UnboundedUInt> computeAllocation, OptionalValue<UnboundedUInt> memoryAllocation, OptionalValue<UnboundedUInt> freezingThreshold, OptionalValue<UnboundedUInt> reservedCyclesLimit, OptionalValue<LogVisibility> logVisibility, OptionalValue<UnboundedUInt> wasmMemoryLimit, OptionalValue<UnboundedUInt> wasmMemoryThreshold)
		{
			this.Controllers = controllers;
			this.ComputeAllocation = computeAllocation;
			this.MemoryAllocation = memoryAllocation;
			this.FreezingThreshold = freezingThreshold;
			this.ReservedCyclesLimit = reservedCyclesLimit;
			this.LogVisibility = logVisibility;
			this.WasmMemoryLimit = wasmMemoryLimit;
			this.WasmMemoryThreshold = wasmMemoryThreshold;
		}

		public CanisterSettings()
		{
		}
	}
}