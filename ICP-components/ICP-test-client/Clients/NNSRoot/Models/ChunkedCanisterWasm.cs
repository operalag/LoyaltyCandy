using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class ChunkedCanisterWasm
	{
		[CandidName("wasm_module_hash")]
		public List<byte> WasmModuleHash { get; set; }

		[CandidName("store_canister_id")]
		public Principal StoreCanisterId { get; set; }

		[CandidName("chunk_hashes_list")]
		public List<List<byte>> ChunkHashesList { get; set; }

		public ChunkedCanisterWasm(List<byte> wasmModuleHash, Principal storeCanisterId, List<List<byte>> chunkHashesList)
		{
			this.WasmModuleHash = wasmModuleHash;
			this.StoreCanisterId = storeCanisterId;
			this.ChunkHashesList = chunkHashesList;
		}

		public ChunkedCanisterWasm()
		{
		}
	}
}