using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class AddNodePayload
	{
		[CandidName("prometheus_metrics_endpoint")]
		public string PrometheusMetricsEndpoint { get; set; }

		[CandidName("http_endpoint")]
		public string HttpEndpoint { get; set; }

		[CandidName("idkg_dealing_encryption_pk")]
		public OptionalValue<List<byte>> IdkgDealingEncryptionPk { get; set; }

		[CandidName("domain")]
		public OptionalValue<string> Domain { get; set; }

		[CandidName("public_ipv4_config")]
		public OptionalValue<IPv4Config> PublicIpv4Config { get; set; }

		[CandidName("xnet_endpoint")]
		public string XnetEndpoint { get; set; }

		[CandidName("chip_id")]
		public OptionalValue<List<byte>> ChipId { get; set; }

		[CandidName("committee_signing_pk")]
		public List<byte> CommitteeSigningPk { get; set; }

		[CandidName("node_signing_pk")]
		public List<byte> NodeSigningPk { get; set; }

		[CandidName("transport_tls_cert")]
		public List<byte> TransportTlsCert { get; set; }

		[CandidName("ni_dkg_dealing_encryption_pk")]
		public List<byte> NiDkgDealingEncryptionPk { get; set; }

		[CandidName("p2p_flow_endpoints")]
		public List<string> P2pFlowEndpoints { get; set; }

		[CandidName("node_reward_type")]
		public OptionalValue<string> NodeRewardType { get; set; }

		public AddNodePayload(string prometheusMetricsEndpoint, string httpEndpoint, OptionalValue<List<byte>> idkgDealingEncryptionPk, OptionalValue<string> domain, OptionalValue<IPv4Config> publicIpv4Config, string xnetEndpoint, OptionalValue<List<byte>> chipId, List<byte> committeeSigningPk, List<byte> nodeSigningPk, List<byte> transportTlsCert, List<byte> niDkgDealingEncryptionPk, List<string> p2pFlowEndpoints, OptionalValue<string> nodeRewardType)
		{
			this.PrometheusMetricsEndpoint = prometheusMetricsEndpoint;
			this.HttpEndpoint = httpEndpoint;
			this.IdkgDealingEncryptionPk = idkgDealingEncryptionPk;
			this.Domain = domain;
			this.PublicIpv4Config = publicIpv4Config;
			this.XnetEndpoint = xnetEndpoint;
			this.ChipId = chipId;
			this.CommitteeSigningPk = committeeSigningPk;
			this.NodeSigningPk = nodeSigningPk;
			this.TransportTlsCert = transportTlsCert;
			this.NiDkgDealingEncryptionPk = niDkgDealingEncryptionPk;
			this.P2pFlowEndpoints = p2pFlowEndpoints;
			this.NodeRewardType = nodeRewardType;
		}

		public AddNodePayload()
		{
		}
	}
}