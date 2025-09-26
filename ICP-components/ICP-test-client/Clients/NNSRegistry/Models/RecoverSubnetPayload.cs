using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class RecoverSubnetPayload
	{
		[CandidName("height")]
		public ulong Height { get; set; }

		[CandidName("replacement_nodes")]
		public OptionalValue<List<Principal>> ReplacementNodes { get; set; }

		[CandidName("subnet_id")]
		public Principal SubnetId { get; set; }

		[CandidName("registry_store_uri")]
		public OptionalValue<(string, string, ulong)> RegistryStoreUri { get; set; }

		[CandidName("chain_key_config")]
		public OptionalValue<InitialChainKeyConfig> ChainKeyConfig { get; set; }

		[CandidName("state_hash")]
		public List<byte> StateHash { get; set; }

		[CandidName("time_ns")]
		public ulong TimeNs { get; set; }

		public RecoverSubnetPayload(ulong height, OptionalValue<List<Principal>> replacementNodes, Principal subnetId, OptionalValue<(string, string, ulong)> registryStoreUri, OptionalValue<InitialChainKeyConfig> chainKeyConfig, List<byte> stateHash, ulong timeNs)
		{
			this.Height = height;
			this.ReplacementNodes = replacementNodes;
			this.SubnetId = subnetId;
			this.RegistryStoreUri = registryStoreUri;
			this.ChainKeyConfig = chainKeyConfig;
			this.StateHash = stateHash;
			this.TimeNs = timeNs;
		}

		public RecoverSubnetPayload()
		{
		}
	}
}