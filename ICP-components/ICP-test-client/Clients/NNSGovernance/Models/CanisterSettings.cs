using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class CanisterSettings
	{
		[CandidName("freezing_threshold")]
		public OptionalValue<ulong> FreezingThreshold { get; set; }

		[CandidName("controllers")]
		public OptionalValue<Controllers> Controllers { get; set; }

		[CandidName("log_visibility")]
		public OptionalValue<int> LogVisibility { get; set; }

		[CandidName("wasm_memory_limit")]
		public OptionalValue<ulong> WasmMemoryLimit { get; set; }

		[CandidName("memory_allocation")]
		public OptionalValue<ulong> MemoryAllocation { get; set; }

		[CandidName("compute_allocation")]
		public OptionalValue<ulong> ComputeAllocation { get; set; }

		[CandidName("wasm_memory_threshold")]
		public OptionalValue<ulong> WasmMemoryThreshold { get; set; }

		public CanisterSettings(OptionalValue<ulong> freezingThreshold, OptionalValue<Controllers> controllers, OptionalValue<int> logVisibility, OptionalValue<ulong> wasmMemoryLimit, OptionalValue<ulong> memoryAllocation, OptionalValue<ulong> computeAllocation, OptionalValue<ulong> wasmMemoryThreshold)
		{
			this.FreezingThreshold = freezingThreshold;
			this.Controllers = controllers;
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