using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Governance
	{
		[CandidName("default_followees")]
		public Dictionary<int, Followees> DefaultFollowees { get; set; }

		[CandidName("making_sns_proposal")]
		public OptionalValue<MakingSnsProposal> MakingSnsProposal { get; set; }

		[CandidName("most_recent_monthly_node_provider_rewards")]
		public OptionalValue<MonthlyNodeProviderRewards> MostRecentMonthlyNodeProviderRewards { get; set; }

		[CandidName("maturity_modulation_last_updated_at_timestamp_seconds")]
		public OptionalValue<ulong> MaturityModulationLastUpdatedAtTimestampSeconds { get; set; }

		[CandidName("wait_for_quiet_threshold_seconds")]
		public ulong WaitForQuietThresholdSeconds { get; set; }

		[CandidName("metrics")]
		public OptionalValue<GovernanceCachedMetrics> Metrics { get; set; }

		[CandidName("neuron_management_voting_period_seconds")]
		public OptionalValue<ulong> NeuronManagementVotingPeriodSeconds { get; set; }

		[CandidName("node_providers")]
		public List<NodeProvider> NodeProviders { get; set; }

		[CandidName("cached_daily_maturity_modulation_basis_points")]
		public OptionalValue<int> CachedDailyMaturityModulationBasisPoints { get; set; }

		[CandidName("economics")]
		public OptionalValue<NetworkEconomics> Economics { get; set; }

		[CandidName("restore_aging_summary")]
		public OptionalValue<RestoreAgingSummary> RestoreAgingSummary { get; set; }

		[CandidName("spawning_neurons")]
		public OptionalValue<bool> SpawningNeurons { get; set; }

		[CandidName("latest_reward_event")]
		public OptionalValue<RewardEvent> LatestRewardEvent { get; set; }

		[CandidName("to_claim_transfers")]
		public List<NeuronStakeTransfer> ToClaimTransfers { get; set; }

		[CandidName("short_voting_period_seconds")]
		public ulong ShortVotingPeriodSeconds { get; set; }

		[CandidName("proposals")]
		public Dictionary<ulong, ProposalData> Proposals { get; set; }

		[CandidName("xdr_conversion_rate")]
		public OptionalValue<XdrConversionRate> XdrConversionRate { get; set; }

		[CandidName("in_flight_commands")]
		public Dictionary<ulong, NeuronInFlightCommand> InFlightCommands { get; set; }

		[CandidName("neurons")]
		public Dictionary<ulong, Neuron> Neurons { get; set; }

		[CandidName("genesis_timestamp_seconds")]
		public ulong GenesisTimestampSeconds { get; set; }

		public Governance(Dictionary<int, Followees> defaultFollowees, OptionalValue<MakingSnsProposal> makingSnsProposal, OptionalValue<MonthlyNodeProviderRewards> mostRecentMonthlyNodeProviderRewards, OptionalValue<ulong> maturityModulationLastUpdatedAtTimestampSeconds, ulong waitForQuietThresholdSeconds, OptionalValue<GovernanceCachedMetrics> metrics, OptionalValue<ulong> neuronManagementVotingPeriodSeconds, List<NodeProvider> nodeProviders, OptionalValue<int> cachedDailyMaturityModulationBasisPoints, OptionalValue<NetworkEconomics> economics, OptionalValue<RestoreAgingSummary> restoreAgingSummary, OptionalValue<bool> spawningNeurons, OptionalValue<RewardEvent> latestRewardEvent, List<NeuronStakeTransfer> toClaimTransfers, ulong shortVotingPeriodSeconds, Dictionary<ulong, ProposalData> proposals, OptionalValue<XdrConversionRate> xdrConversionRate, Dictionary<ulong, NeuronInFlightCommand> inFlightCommands, Dictionary<ulong, Neuron> neurons, ulong genesisTimestampSeconds)
		{
			this.DefaultFollowees = defaultFollowees;
			this.MakingSnsProposal = makingSnsProposal;
			this.MostRecentMonthlyNodeProviderRewards = mostRecentMonthlyNodeProviderRewards;
			this.MaturityModulationLastUpdatedAtTimestampSeconds = maturityModulationLastUpdatedAtTimestampSeconds;
			this.WaitForQuietThresholdSeconds = waitForQuietThresholdSeconds;
			this.Metrics = metrics;
			this.NeuronManagementVotingPeriodSeconds = neuronManagementVotingPeriodSeconds;
			this.NodeProviders = nodeProviders;
			this.CachedDailyMaturityModulationBasisPoints = cachedDailyMaturityModulationBasisPoints;
			this.Economics = economics;
			this.RestoreAgingSummary = restoreAgingSummary;
			this.SpawningNeurons = spawningNeurons;
			this.LatestRewardEvent = latestRewardEvent;
			this.ToClaimTransfers = toClaimTransfers;
			this.ShortVotingPeriodSeconds = shortVotingPeriodSeconds;
			this.Proposals = proposals;
			this.XdrConversionRate = xdrConversionRate;
			this.InFlightCommands = inFlightCommands;
			this.Neurons = neurons;
			this.GenesisTimestampSeconds = genesisTimestampSeconds;
		}

		public Governance()
		{
		}
	}
}