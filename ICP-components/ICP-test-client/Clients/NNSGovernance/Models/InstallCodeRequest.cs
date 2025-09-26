using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class InstallCodeRequest
	{
		[CandidName("arg")]
		public OptionalValue<List<byte>> Arg { get; set; }

		[CandidName("wasm_module")]
		public OptionalValue<List<byte>> WasmModule { get; set; }

		[CandidName("skip_stopping_before_installing")]
		public OptionalValue<bool> SkipStoppingBeforeInstalling { get; set; }

		[CandidName("canister_id")]
		public OptionalValue<Principal> CanisterId { get; set; }

		[CandidName("install_mode")]
		public OptionalValue<int> InstallMode { get; set; }

		public InstallCodeRequest(OptionalValue<List<byte>> arg, OptionalValue<List<byte>> wasmModule, OptionalValue<bool> skipStoppingBeforeInstalling, OptionalValue<Principal> canisterId, OptionalValue<int> installMode)
		{
			this.Arg = arg;
			this.WasmModule = wasmModule;
			this.SkipStoppingBeforeInstalling = skipStoppingBeforeInstalling;
			this.CanisterId = canisterId;
			this.InstallMode = installMode;
		}

		public InstallCodeRequest()
		{
		}
	}
}