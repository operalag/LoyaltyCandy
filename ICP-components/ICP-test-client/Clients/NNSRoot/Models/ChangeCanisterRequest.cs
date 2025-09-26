using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRoot.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class ChangeCanisterRequest
	{
		[CandidName("arg")]
		public List<byte> Arg { get; set; }

		[CandidName("wasm_module")]
		public List<byte> WasmModule { get; set; }

		[CandidName("chunked_canister_wasm")]
		public OptionalValue<ChunkedCanisterWasm> ChunkedCanisterWasm { get; set; }

		[CandidName("stop_before_installing")]
		public bool StopBeforeInstalling { get; set; }

		[CandidName("mode")]
		public CanisterInstallMode Mode { get; set; }

		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		[CandidName("memory_allocation")]
		public OptionalValue<UnboundedUInt> MemoryAllocation { get; set; }

		[CandidName("compute_allocation")]
		public OptionalValue<UnboundedUInt> ComputeAllocation { get; set; }

		public ChangeCanisterRequest(List<byte> arg, List<byte> wasmModule, OptionalValue<ChunkedCanisterWasm> chunkedCanisterWasm, bool stopBeforeInstalling, CanisterInstallMode mode, Principal canisterId, OptionalValue<UnboundedUInt> memoryAllocation, OptionalValue<UnboundedUInt> computeAllocation)
		{
			this.Arg = arg;
			this.WasmModule = wasmModule;
			this.ChunkedCanisterWasm = chunkedCanisterWasm;
			this.StopBeforeInstalling = stopBeforeInstalling;
			this.Mode = mode;
			this.CanisterId = canisterId;
			this.MemoryAllocation = memoryAllocation;
			this.ComputeAllocation = computeAllocation;
		}

		public ChangeCanisterRequest()
		{
		}
	}
}