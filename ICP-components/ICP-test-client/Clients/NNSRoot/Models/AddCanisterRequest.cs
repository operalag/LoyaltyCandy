using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class AddCanisterRequest
	{
		[CandidName("arg")]
		public List<byte> Arg { get; set; }

		[CandidName("initial_cycles")]
		public ulong InitialCycles { get; set; }

		[CandidName("wasm_module")]
		public List<byte> WasmModule { get; set; }

		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("memory_allocation")]
		public OptionalValue<UnboundedUInt> MemoryAllocation { get; set; }

		[CandidName("compute_allocation")]
		public OptionalValue<UnboundedUInt> ComputeAllocation { get; set; }

		public AddCanisterRequest(List<byte> arg, ulong initialCycles, List<byte> wasmModule, string name, OptionalValue<UnboundedUInt> memoryAllocation, OptionalValue<UnboundedUInt> computeAllocation)
		{
			this.Arg = arg;
			this.InitialCycles = initialCycles;
			this.WasmModule = wasmModule;
			this.Name = name;
			this.MemoryAllocation = memoryAllocation;
			this.ComputeAllocation = computeAllocation;
		}

		public AddCanisterRequest()
		{
		}
	}
}