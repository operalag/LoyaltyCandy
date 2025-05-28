using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSRoot.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class CanisterSettings
	{
		[CandidName("freezing_threshold")]
		public OptionalValue<UnboundedUInt> FreezingThreshold { get; set; }

		[CandidName("controllers")]
		public OptionalValue<List<Principal>> Controllers { get; set; }

		[CandidName("reserved_cycles_limit")]
		public OptionalValue<UnboundedUInt> ReservedCyclesLimit { get; set; }

		[CandidName("log_visibility")]
		public OptionalValue<LogVisibility> LogVisibility { get; set; }

		[CandidName("wasm_memory_limit")]
		public OptionalValue<UnboundedUInt> WasmMemoryLimit { get; set; }

		[CandidName("memory_allocation")]
		public OptionalValue<UnboundedUInt> MemoryAllocation { get; set; }

		[CandidName("compute_allocation")]
		public OptionalValue<UnboundedUInt> ComputeAllocation { get; set; }

		[CandidName("wasm_memory_threshold")]
		public OptionalValue<UnboundedUInt> WasmMemoryThreshold { get; set; }

		public CanisterSettings(OptionalValue<UnboundedUInt> freezingThreshold, OptionalValue<List<Principal>> controllers, OptionalValue<UnboundedUInt> reservedCyclesLimit, OptionalValue<LogVisibility> logVisibility, OptionalValue<UnboundedUInt> wasmMemoryLimit, OptionalValue<UnboundedUInt> memoryAllocation, OptionalValue<UnboundedUInt> computeAllocation, OptionalValue<UnboundedUInt> wasmMemoryThreshold)
		{
			this.FreezingThreshold = freezingThreshold;
			this.Controllers = controllers;
			this.ReservedCyclesLimit = reservedCyclesLimit;
			this.LogVisibility = logVisibility;
			this.WasmMemoryLimit = wasmMemoryLimit;
			this.MemoryAllocation = memoryAllocation;
			this.ComputeAllocation = computeAllocation;
			this.WasmMemoryThreshold = wasmMemoryThreshold;
		}

		public CanisterSettings()
		{
		}
	}
}