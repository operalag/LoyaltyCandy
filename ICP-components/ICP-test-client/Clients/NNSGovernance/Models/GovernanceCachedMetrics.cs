using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class GovernanceCachedMetrics
	{
		[CandidName("total_maturity_e8s_equivalent")]
		public ulong TotalMaturityE8sEquivalent { get; set; }

		[CandidName("not_dissolving_neurons_e8s_buckets")]
		public Dictionary<ulong, double> NotDissolvingNeuronsE8sBuckets { get; set; }

		[CandidName("dissolving_neurons_staked_maturity_e8s_equivalent_sum")]
		public ulong DissolvingNeuronsStakedMaturityE8sEquivalentSum { get; set; }

		[CandidName("garbage_collectable_neurons_count")]
		public ulong GarbageCollectableNeuronsCount { get; set; }

		[CandidName("dissolving_neurons_staked_maturity_e8s_equivalent_buckets")]
		public Dictionary<ulong, double> DissolvingNeuronsStakedMaturityE8sEquivalentBuckets { get; set; }

		[CandidName("neurons_with_invalid_stake_count")]
		public ulong NeuronsWithInvalidStakeCount { get; set; }

		[CandidName("not_dissolving_neurons_count_buckets")]
		public Dictionary<ulong, ulong> NotDissolvingNeuronsCountBuckets { get; set; }

		[CandidName("ect_neuron_count")]
		public ulong EctNeuronCount { get; set; }

		[CandidName("total_supply_icp")]
		public ulong TotalSupplyIcp { get; set; }

		[CandidName("neurons_with_less_than_6_months_dissolve_delay_count")]
		public ulong NeuronsWithLessThan6MonthsDissolveDelayCount { get; set; }

		[CandidName("dissolved_neurons_count")]
		public ulong DissolvedNeuronsCount { get; set; }

		[CandidName("community_fund_total_maturity_e8s_equivalent")]
		public ulong CommunityFundTotalMaturityE8sEquivalent { get; set; }

		[CandidName("total_staked_e8s_seed")]
		public ulong TotalStakedE8sSeed { get; set; }

		[CandidName("total_staked_maturity_e8s_equivalent_ect")]
		public ulong TotalStakedMaturityE8sEquivalentEct { get; set; }

		[CandidName("total_staked_e8s")]
		public ulong TotalStakedE8s { get; set; }

		[CandidName("not_dissolving_neurons_count")]
		public ulong NotDissolvingNeuronsCount { get; set; }

		[CandidName("total_locked_e8s")]
		public ulong TotalLockedE8s { get; set; }

		[CandidName("neurons_fund_total_active_neurons")]
		public ulong NeuronsFundTotalActiveNeurons { get; set; }

		[CandidName("total_voting_power_non_self_authenticating_controller")]
		public OptionalValue<ulong> TotalVotingPowerNonSelfAuthenticatingController { get; set; }

		[CandidName("total_staked_maturity_e8s_equivalent")]
		public ulong TotalStakedMaturityE8sEquivalent { get; set; }

		[CandidName("not_dissolving_neurons_e8s_buckets_ect")]
		public Dictionary<ulong, double> NotDissolvingNeuronsE8sBucketsEct { get; set; }

		[CandidName("total_staked_e8s_ect")]
		public ulong TotalStakedE8sEct { get; set; }

		[CandidName("not_dissolving_neurons_staked_maturity_e8s_equivalent_sum")]
		public ulong NotDissolvingNeuronsStakedMaturityE8sEquivalentSum { get; set; }

		[CandidName("dissolved_neurons_e8s")]
		public ulong DissolvedNeuronsE8s { get; set; }

		[CandidName("total_staked_e8s_non_self_authenticating_controller")]
		public OptionalValue<ulong> TotalStakedE8sNonSelfAuthenticatingController { get; set; }

		[CandidName("dissolving_neurons_e8s_buckets_seed")]
		public Dictionary<ulong, double> DissolvingNeuronsE8sBucketsSeed { get; set; }

		[CandidName("neurons_with_less_than_6_months_dissolve_delay_e8s")]
		public ulong NeuronsWithLessThan6MonthsDissolveDelayE8s { get; set; }

		[CandidName("not_dissolving_neurons_staked_maturity_e8s_equivalent_buckets")]
		public Dictionary<ulong, double> NotDissolvingNeuronsStakedMaturityE8sEquivalentBuckets { get; set; }

		[CandidName("dissolving_neurons_count_buckets")]
		public Dictionary<ulong, ulong> DissolvingNeuronsCountBuckets { get; set; }

		[CandidName("dissolving_neurons_e8s_buckets_ect")]
		public Dictionary<ulong, double> DissolvingNeuronsE8sBucketsEct { get; set; }

		[CandidName("dissolving_neurons_count")]
		public ulong DissolvingNeuronsCount { get; set; }

		[CandidName("dissolving_neurons_e8s_buckets")]
		public Dictionary<ulong, double> DissolvingNeuronsE8sBuckets { get; set; }

		[CandidName("total_staked_maturity_e8s_equivalent_seed")]
		public ulong TotalStakedMaturityE8sEquivalentSeed { get; set; }

		[CandidName("community_fund_total_staked_e8s")]
		public ulong CommunityFundTotalStakedE8s { get; set; }

		[CandidName("not_dissolving_neurons_e8s_buckets_seed")]
		public Dictionary<ulong, double> NotDissolvingNeuronsE8sBucketsSeed { get; set; }

		[CandidName("timestamp_seconds")]
		public ulong TimestampSeconds { get; set; }

		[CandidName("seed_neuron_count")]
		public ulong SeedNeuronCount { get; set; }

		[CandidName("non_self_authenticating_controller_neuron_subset_metrics")]
		public OptionalValue<NeuronSubsetMetrics> NonSelfAuthenticatingControllerNeuronSubsetMetrics { get; set; }

		[CandidName("public_neuron_subset_metrics")]
		public OptionalValue<NeuronSubsetMetrics> PublicNeuronSubsetMetrics { get; set; }

		[CandidName("declining_voting_power_neuron_subset_metrics")]
		public OptionalValue<NeuronSubsetMetrics> DecliningVotingPowerNeuronSubsetMetrics { get; set; }

		[CandidName("fully_lost_voting_power_neuron_subset_metrics")]
		public OptionalValue<NeuronSubsetMetrics> FullyLostVotingPowerNeuronSubsetMetrics { get; set; }

		public GovernanceCachedMetrics(ulong totalMaturityE8sEquivalent, Dictionary<ulong, double> notDissolvingNeuronsE8sBuckets, ulong dissolvingNeuronsStakedMaturityE8sEquivalentSum, ulong garbageCollectableNeuronsCount, Dictionary<ulong, double> dissolvingNeuronsStakedMaturityE8sEquivalentBuckets, ulong neuronsWithInvalidStakeCount, Dictionary<ulong, ulong> notDissolvingNeuronsCountBuckets, ulong ectNeuronCount, ulong totalSupplyIcp, ulong neuronsWithLessThan6MonthsDissolveDelayCount, ulong dissolvedNeuronsCount, ulong communityFundTotalMaturityE8sEquivalent, ulong totalStakedE8sSeed, ulong totalStakedMaturityE8sEquivalentEct, ulong totalStakedE8s, ulong notDissolvingNeuronsCount, ulong totalLockedE8s, ulong neuronsFundTotalActiveNeurons, OptionalValue<ulong> totalVotingPowerNonSelfAuthenticatingController, ulong totalStakedMaturityE8sEquivalent, Dictionary<ulong, double> notDissolvingNeuronsE8sBucketsEct, ulong totalStakedE8sEct, ulong notDissolvingNeuronsStakedMaturityE8sEquivalentSum, ulong dissolvedNeuronsE8s, OptionalValue<ulong> totalStakedE8sNonSelfAuthenticatingController, Dictionary<ulong, double> dissolvingNeuronsE8sBucketsSeed, ulong neuronsWithLessThan6MonthsDissolveDelayE8s, Dictionary<ulong, double> notDissolvingNeuronsStakedMaturityE8sEquivalentBuckets, Dictionary<ulong, ulong> dissolvingNeuronsCountBuckets, Dictionary<ulong, double> dissolvingNeuronsE8sBucketsEct, ulong dissolvingNeuronsCount, Dictionary<ulong, double> dissolvingNeuronsE8sBuckets, ulong totalStakedMaturityE8sEquivalentSeed, ulong communityFundTotalStakedE8s, Dictionary<ulong, double> notDissolvingNeuronsE8sBucketsSeed, ulong timestampSeconds, ulong seedNeuronCount, OptionalValue<NeuronSubsetMetrics> nonSelfAuthenticatingControllerNeuronSubsetMetrics, OptionalValue<NeuronSubsetMetrics> publicNeuronSubsetMetrics, OptionalValue<NeuronSubsetMetrics> decliningVotingPowerNeuronSubsetMetrics, OptionalValue<NeuronSubsetMetrics> fullyLostVotingPowerNeuronSubsetMetrics)
		{
			this.TotalMaturityE8sEquivalent = totalMaturityE8sEquivalent;
			this.NotDissolvingNeuronsE8sBuckets = notDissolvingNeuronsE8sBuckets;
			this.DissolvingNeuronsStakedMaturityE8sEquivalentSum = dissolvingNeuronsStakedMaturityE8sEquivalentSum;
			this.GarbageCollectableNeuronsCount = garbageCollectableNeuronsCount;
			this.DissolvingNeuronsStakedMaturityE8sEquivalentBuckets = dissolvingNeuronsStakedMaturityE8sEquivalentBuckets;
			this.NeuronsWithInvalidStakeCount = neuronsWithInvalidStakeCount;
			this.NotDissolvingNeuronsCountBuckets = notDissolvingNeuronsCountBuckets;
			this.EctNeuronCount = ectNeuronCount;
			this.TotalSupplyIcp = totalSupplyIcp;
			this.NeuronsWithLessThan6MonthsDissolveDelayCount = neuronsWithLessThan6MonthsDissolveDelayCount;
			this.DissolvedNeuronsCount = dissolvedNeuronsCount;
			this.CommunityFundTotalMaturityE8sEquivalent = communityFundTotalMaturityE8sEquivalent;
			this.TotalStakedE8sSeed = totalStakedE8sSeed;
			this.TotalStakedMaturityE8sEquivalentEct = totalStakedMaturityE8sEquivalentEct;
			this.TotalStakedE8s = totalStakedE8s;
			this.NotDissolvingNeuronsCount = notDissolvingNeuronsCount;
			this.TotalLockedE8s = totalLockedE8s;
			this.NeuronsFundTotalActiveNeurons = neuronsFundTotalActiveNeurons;
			this.TotalVotingPowerNonSelfAuthenticatingController = totalVotingPowerNonSelfAuthenticatingController;
			this.TotalStakedMaturityE8sEquivalent = totalStakedMaturityE8sEquivalent;
			this.NotDissolvingNeuronsE8sBucketsEct = notDissolvingNeuronsE8sBucketsEct;
			this.TotalStakedE8sEct = totalStakedE8sEct;
			this.NotDissolvingNeuronsStakedMaturityE8sEquivalentSum = notDissolvingNeuronsStakedMaturityE8sEquivalentSum;
			this.DissolvedNeuronsE8s = dissolvedNeuronsE8s;
			this.TotalStakedE8sNonSelfAuthenticatingController = totalStakedE8sNonSelfAuthenticatingController;
			this.DissolvingNeuronsE8sBucketsSeed = dissolvingNeuronsE8sBucketsSeed;
			this.NeuronsWithLessThan6MonthsDissolveDelayE8s = neuronsWithLessThan6MonthsDissolveDelayE8s;
			this.NotDissolvingNeuronsStakedMaturityE8sEquivalentBuckets = notDissolvingNeuronsStakedMaturityE8sEquivalentBuckets;
			this.DissolvingNeuronsCountBuckets = dissolvingNeuronsCountBuckets;
			this.DissolvingNeuronsE8sBucketsEct = dissolvingNeuronsE8sBucketsEct;
			this.DissolvingNeuronsCount = dissolvingNeuronsCount;
			this.DissolvingNeuronsE8sBuckets = dissolvingNeuronsE8sBuckets;
			this.TotalStakedMaturityE8sEquivalentSeed = totalStakedMaturityE8sEquivalentSeed;
			this.CommunityFundTotalStakedE8s = communityFundTotalStakedE8s;
			this.NotDissolvingNeuronsE8sBucketsSeed = notDissolvingNeuronsE8sBucketsSeed;
			this.TimestampSeconds = timestampSeconds;
			this.SeedNeuronCount = seedNeuronCount;
			this.NonSelfAuthenticatingControllerNeuronSubsetMetrics = nonSelfAuthenticatingControllerNeuronSubsetMetrics;
			this.PublicNeuronSubsetMetrics = publicNeuronSubsetMetrics;
			this.DecliningVotingPowerNeuronSubsetMetrics = decliningVotingPowerNeuronSubsetMetrics;
			this.FullyLostVotingPowerNeuronSubsetMetrics = fullyLostVotingPowerNeuronSubsetMetrics;
		}

		public GovernanceCachedMetrics()
		{
		}
	}
}