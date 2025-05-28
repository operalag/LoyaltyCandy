using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class InstallCode
	{
		[CandidName("skip_stopping_before_installing")]
		public OptionalValue<bool> SkipStoppingBeforeInstalling { get; set; }

		[CandidName("wasm_module_hash")]
		public OptionalValue<List<byte>> WasmModuleHash { get; set; }

		[CandidName("canister_id")]
		public OptionalValue<Principal> CanisterId { get; set; }

		[CandidName("arg_hash")]
		public OptionalValue<List<byte>> ArgHash { get; set; }

		[CandidName("install_mode")]
		public OptionalValue<int> InstallMode { get; set; }

		public InstallCode(OptionalValue<bool> skipStoppingBeforeInstalling, OptionalValue<List<byte>> wasmModuleHash, OptionalValue<Principal> canisterId, OptionalValue<List<byte>> argHash, OptionalValue<int> installMode)
		{
			this.SkipStoppingBeforeInstalling = skipStoppingBeforeInstalling;
			this.WasmModuleHash = wasmModuleHash;
			this.CanisterId = canisterId;
			this.ArgHash = argHash;
			this.InstallMode = installMode;
		}

		public InstallCode()
		{
		}
	}
}