using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRegistry.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateSubnetPayload
	{
		[CandidName("unit_delay_millis")]
		public OptionalValue<ulong> UnitDelayMillis { get; set; }

		[CandidName("max_duplicity")]
		public OptionalValue<uint> MaxDuplicity { get; set; }

		[CandidName("features")]
		public OptionalValue<SubnetFeatures> Features { get; set; }

		[CandidName("set_gossip_config_to_default")]
		public bool SetGossipConfigToDefault { get; set; }

		[CandidName("halt_at_cup_height")]
		public OptionalValue<bool> HaltAtCupHeight { get; set; }

		[CandidName("pfn_evaluation_period_ms")]
		public OptionalValue<uint> PfnEvaluationPeriodMs { get; set; }

		[CandidName("subnet_id")]
		public Principal SubnetId { get; set; }

		[CandidName("max_ingress_bytes_per_message")]
		public OptionalValue<ulong> MaxIngressBytesPerMessage { get; set; }

		[CandidName("dkg_dealings_per_block")]
		public OptionalValue<ulong> DkgDealingsPerBlock { get; set; }

		[CandidName("max_block_payload_size")]
		public OptionalValue<ulong> MaxBlockPayloadSize { get; set; }

		[CandidName("start_as_nns")]
		public OptionalValue<bool> StartAsNns { get; set; }

		[CandidName("is_halted")]
		public OptionalValue<bool> IsHalted { get; set; }

		[CandidName("max_ingress_messages_per_block")]
		public OptionalValue<ulong> MaxIngressMessagesPerBlock { get; set; }

		[CandidName("max_number_of_canisters")]
		public OptionalValue<ulong> MaxNumberOfCanisters { get; set; }

		[CandidName("retransmission_request_ms")]
		public OptionalValue<uint> RetransmissionRequestMs { get; set; }

		[CandidName("dkg_interval_length")]
		public OptionalValue<ulong> DkgIntervalLength { get; set; }

		[CandidName("registry_poll_period_ms")]
		public OptionalValue<uint> RegistryPollPeriodMs { get; set; }

		[CandidName("max_chunk_wait_ms")]
		public OptionalValue<uint> MaxChunkWaitMs { get; set; }

		[CandidName("receive_check_cache_size")]
		public OptionalValue<uint> ReceiveCheckCacheSize { get; set; }

		[CandidName("ssh_backup_access")]
		public OptionalValue<List<string>> SshBackupAccess { get; set; }

		[CandidName("max_chunk_size")]
		public OptionalValue<uint> MaxChunkSize { get; set; }

		[CandidName("initial_notary_delay_millis")]
		public OptionalValue<ulong> InitialNotaryDelayMillis { get; set; }

		[CandidName("max_artifact_streams_per_peer")]
		public OptionalValue<uint> MaxArtifactStreamsPerPeer { get; set; }

		[CandidName("subnet_type")]
		public OptionalValue<SubnetType> SubnetType { get; set; }

		[CandidName("ssh_readonly_access")]
		public OptionalValue<List<string>> SshReadonlyAccess { get; set; }

		[CandidName("chain_key_config")]
		public OptionalValue<ChainKeyConfig> ChainKeyConfig { get; set; }

		[CandidName("chain_key_signing_enable")]
		public OptionalValue<List<MasterPublicKeyId>> ChainKeySigningEnable { get; set; }

		[CandidName("chain_key_signing_disable")]
		public OptionalValue<List<MasterPublicKeyId>> ChainKeySigningDisable { get; set; }

		public UpdateSubnetPayload(OptionalValue<ulong> unitDelayMillis, OptionalValue<uint> maxDuplicity, OptionalValue<SubnetFeatures> features, bool setGossipConfigToDefault, OptionalValue<bool> haltAtCupHeight, OptionalValue<uint> pfnEvaluationPeriodMs, Principal subnetId, OptionalValue<ulong> maxIngressBytesPerMessage, OptionalValue<ulong> dkgDealingsPerBlock, OptionalValue<ulong> maxBlockPayloadSize, OptionalValue<bool> startAsNns, OptionalValue<bool> isHalted, OptionalValue<ulong> maxIngressMessagesPerBlock, OptionalValue<ulong> maxNumberOfCanisters, OptionalValue<uint> retransmissionRequestMs, OptionalValue<ulong> dkgIntervalLength, OptionalValue<uint> registryPollPeriodMs, OptionalValue<uint> maxChunkWaitMs, OptionalValue<uint> receiveCheckCacheSize, OptionalValue<List<string>> sshBackupAccess, OptionalValue<uint> maxChunkSize, OptionalValue<ulong> initialNotaryDelayMillis, OptionalValue<uint> maxArtifactStreamsPerPeer, OptionalValue<SubnetType> subnetType, OptionalValue<List<string>> sshReadonlyAccess, OptionalValue<ChainKeyConfig> chainKeyConfig, OptionalValue<List<MasterPublicKeyId>> chainKeySigningEnable, OptionalValue<List<MasterPublicKeyId>> chainKeySigningDisable)
		{
			this.UnitDelayMillis = unitDelayMillis;
			this.MaxDuplicity = maxDuplicity;
			this.Features = features;
			this.SetGossipConfigToDefault = setGossipConfigToDefault;
			this.HaltAtCupHeight = haltAtCupHeight;
			this.PfnEvaluationPeriodMs = pfnEvaluationPeriodMs;
			this.SubnetId = subnetId;
			this.MaxIngressBytesPerMessage = maxIngressBytesPerMessage;
			this.DkgDealingsPerBlock = dkgDealingsPerBlock;
			this.MaxBlockPayloadSize = maxBlockPayloadSize;
			this.StartAsNns = startAsNns;
			this.IsHalted = isHalted;
			this.MaxIngressMessagesPerBlock = maxIngressMessagesPerBlock;
			this.MaxNumberOfCanisters = maxNumberOfCanisters;
			this.RetransmissionRequestMs = retransmissionRequestMs;
			this.DkgIntervalLength = dkgIntervalLength;
			this.RegistryPollPeriodMs = registryPollPeriodMs;
			this.MaxChunkWaitMs = maxChunkWaitMs;
			this.ReceiveCheckCacheSize = receiveCheckCacheSize;
			this.SshBackupAccess = sshBackupAccess;
			this.MaxChunkSize = maxChunkSize;
			this.InitialNotaryDelayMillis = initialNotaryDelayMillis;
			this.MaxArtifactStreamsPerPeer = maxArtifactStreamsPerPeer;
			this.SubnetType = subnetType;
			this.SshReadonlyAccess = sshReadonlyAccess;
			this.ChainKeyConfig = chainKeyConfig;
			this.ChainKeySigningEnable = chainKeySigningEnable;
			this.ChainKeySigningDisable = chainKeySigningDisable;
		}

		public UpdateSubnetPayload()
		{
		}
	}
}