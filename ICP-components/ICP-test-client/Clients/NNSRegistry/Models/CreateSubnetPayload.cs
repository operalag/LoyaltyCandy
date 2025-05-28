using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class CreateSubnetPayload
	{
		[CandidName("unit_delay_millis")]
		public ulong UnitDelayMillis { get; set; }

		[CandidName("features")]
		public SubnetFeatures Features { get; set; }

		[CandidName("gossip_registry_poll_period_ms")]
		public uint GossipRegistryPollPeriodMs { get; set; }

		[CandidName("max_ingress_bytes_per_message")]
		public ulong MaxIngressBytesPerMessage { get; set; }

		[CandidName("dkg_dealings_per_block")]
		public ulong DkgDealingsPerBlock { get; set; }

		[CandidName("max_block_payload_size")]
		public ulong MaxBlockPayloadSize { get; set; }

		[CandidName("start_as_nns")]
		public bool StartAsNns { get; set; }

		[CandidName("is_halted")]
		public bool IsHalted { get; set; }

		[CandidName("gossip_pfn_evaluation_period_ms")]
		public uint GossipPfnEvaluationPeriodMs { get; set; }

		[CandidName("max_ingress_messages_per_block")]
		public ulong MaxIngressMessagesPerBlock { get; set; }

		[CandidName("max_number_of_canisters")]
		public ulong MaxNumberOfCanisters { get; set; }

		[CandidName("chain_key_config")]
		public OptionalValue<InitialChainKeyConfig> ChainKeyConfig { get; set; }

		[CandidName("gossip_max_artifact_streams_per_peer")]
		public uint GossipMaxArtifactStreamsPerPeer { get; set; }

		[CandidName("replica_version_id")]
		public string ReplicaVersionId { get; set; }

		[CandidName("gossip_max_duplicity")]
		public uint GossipMaxDuplicity { get; set; }

		[CandidName("gossip_max_chunk_wait_ms")]
		public uint GossipMaxChunkWaitMs { get; set; }

		[CandidName("dkg_interval_length")]
		public ulong DkgIntervalLength { get; set; }

		[CandidName("subnet_id_override")]
		public OptionalValue<Principal> SubnetIdOverride { get; set; }

		[CandidName("ssh_backup_access")]
		public List<string> SshBackupAccess { get; set; }

		[CandidName("ingress_bytes_per_block_soft_cap")]
		public ulong IngressBytesPerBlockSoftCap { get; set; }

		[CandidName("initial_notary_delay_millis")]
		public ulong InitialNotaryDelayMillis { get; set; }

		[CandidName("gossip_max_chunk_size")]
		public uint GossipMaxChunkSize { get; set; }

		[CandidName("subnet_type")]
		public SubnetType SubnetType { get; set; }

		[CandidName("ssh_readonly_access")]
		public List<string> SshReadonlyAccess { get; set; }

		[CandidName("gossip_retransmission_request_ms")]
		public uint GossipRetransmissionRequestMs { get; set; }

		[CandidName("gossip_receive_check_cache_size")]
		public uint GossipReceiveCheckCacheSize { get; set; }

		[CandidName("node_ids")]
		public List<Principal> NodeIds { get; set; }

		public CreateSubnetPayload(ulong unitDelayMillis, SubnetFeatures features, uint gossipRegistryPollPeriodMs, ulong maxIngressBytesPerMessage, ulong dkgDealingsPerBlock, ulong maxBlockPayloadSize, bool startAsNns, bool isHalted, uint gossipPfnEvaluationPeriodMs, ulong maxIngressMessagesPerBlock, ulong maxNumberOfCanisters, OptionalValue<InitialChainKeyConfig> chainKeyConfig, uint gossipMaxArtifactStreamsPerPeer, string replicaVersionId, uint gossipMaxDuplicity, uint gossipMaxChunkWaitMs, ulong dkgIntervalLength, OptionalValue<Principal> subnetIdOverride, List<string> sshBackupAccess, ulong ingressBytesPerBlockSoftCap, ulong initialNotaryDelayMillis, uint gossipMaxChunkSize, SubnetType subnetType, List<string> sshReadonlyAccess, uint gossipRetransmissionRequestMs, uint gossipReceiveCheckCacheSize, List<Principal> nodeIds)
		{
			this.UnitDelayMillis = unitDelayMillis;
			this.Features = features;
			this.GossipRegistryPollPeriodMs = gossipRegistryPollPeriodMs;
			this.MaxIngressBytesPerMessage = maxIngressBytesPerMessage;
			this.DkgDealingsPerBlock = dkgDealingsPerBlock;
			this.MaxBlockPayloadSize = maxBlockPayloadSize;
			this.StartAsNns = startAsNns;
			this.IsHalted = isHalted;
			this.GossipPfnEvaluationPeriodMs = gossipPfnEvaluationPeriodMs;
			this.MaxIngressMessagesPerBlock = maxIngressMessagesPerBlock;
			this.MaxNumberOfCanisters = maxNumberOfCanisters;
			this.ChainKeyConfig = chainKeyConfig;
			this.GossipMaxArtifactStreamsPerPeer = gossipMaxArtifactStreamsPerPeer;
			this.ReplicaVersionId = replicaVersionId;
			this.GossipMaxDuplicity = gossipMaxDuplicity;
			this.GossipMaxChunkWaitMs = gossipMaxChunkWaitMs;
			this.DkgIntervalLength = dkgIntervalLength;
			this.SubnetIdOverride = subnetIdOverride;
			this.SshBackupAccess = sshBackupAccess;
			this.IngressBytesPerBlockSoftCap = ingressBytesPerBlockSoftCap;
			this.InitialNotaryDelayMillis = initialNotaryDelayMillis;
			this.GossipMaxChunkSize = gossipMaxChunkSize;
			this.SubnetType = subnetType;
			this.SshReadonlyAccess = sshReadonlyAccess;
			this.GossipRetransmissionRequestMs = gossipRetransmissionRequestMs;
			this.GossipReceiveCheckCacheSize = gossipReceiveCheckCacheSize;
			this.NodeIds = nodeIds;
		}

		public CreateSubnetPayload()
		{
		}
	}
}