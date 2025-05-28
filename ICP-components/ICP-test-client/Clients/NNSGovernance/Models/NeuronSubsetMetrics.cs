using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronSubsetMetrics
	{
		[CandidName("count")]
		public OptionalValue<ulong> Count { get; set; }

		[CandidName("total_staked_e8s")]
		public OptionalValue<ulong> TotalStakedE8s { get; set; }

		[CandidName("total_maturity_e8s_equivalent")]
		public OptionalValue<ulong> TotalMaturityE8sEquivalent { get; set; }

		[CandidName("total_staked_maturity_e8s_equivalent")]
		public OptionalValue<ulong> TotalStakedMaturityE8sEquivalent { get; set; }

		[CandidName("total_voting_power")]
		public OptionalValue<ulong> TotalVotingPower { get; set; }

		[CandidName("total_deciding_voting_power")]
		public OptionalValue<ulong> TotalDecidingVotingPower { get; set; }

		[CandidName("total_potential_voting_power")]
		public OptionalValue<ulong> TotalPotentialVotingPower { get; set; }

		[CandidName("count_buckets")]
		public Dictionary<ulong, ulong> CountBuckets { get; set; }

		[CandidName("staked_e8s_buckets")]
		public Dictionary<ulong, ulong> StakedE8sBuckets { get; set; }

		[CandidName("maturity_e8s_equivalent_buckets")]
		public Dictionary<ulong, ulong> MaturityE8sEquivalentBuckets { get; set; }

		[CandidName("staked_maturity_e8s_equivalent_buckets")]
		public Dictionary<ulong, ulong> StakedMaturityE8sEquivalentBuckets { get; set; }

		[CandidName("voting_power_buckets")]
		public Dictionary<ulong, ulong> VotingPowerBuckets { get; set; }

		[CandidName("deciding_voting_power_buckets")]
		public Dictionary<ulong, ulong> DecidingVotingPowerBuckets { get; set; }

		[CandidName("potential_voting_power_buckets")]
		public Dictionary<ulong, ulong> PotentialVotingPowerBuckets { get; set; }

		public NeuronSubsetMetrics(OptionalValue<ulong> count, OptionalValue<ulong> totalStakedE8s, OptionalValue<ulong> totalMaturityE8sEquivalent, OptionalValue<ulong> totalStakedMaturityE8sEquivalent, OptionalValue<ulong> totalVotingPower, OptionalValue<ulong> totalDecidingVotingPower, OptionalValue<ulong> totalPotentialVotingPower, Dictionary<ulong, ulong> countBuckets, Dictionary<ulong, ulong> stakedE8sBuckets, Dictionary<ulong, ulong> maturityE8sEquivalentBuckets, Dictionary<ulong, ulong> stakedMaturityE8sEquivalentBuckets, Dictionary<ulong, ulong> votingPowerBuckets, Dictionary<ulong, ulong> decidingVotingPowerBuckets, Dictionary<ulong, ulong> potentialVotingPowerBuckets)
		{
			this.Count = count;
			this.TotalStakedE8s = totalStakedE8s;
			this.TotalMaturityE8sEquivalent = totalMaturityE8sEquivalent;
			this.TotalStakedMaturityE8sEquivalent = totalStakedMaturityE8sEquivalent;
			this.TotalVotingPower = totalVotingPower;
			this.TotalDecidingVotingPower = totalDecidingVotingPower;
			this.TotalPotentialVotingPower = totalPotentialVotingPower;
			this.CountBuckets = countBuckets;
			this.StakedE8sBuckets = stakedE8sBuckets;
			this.MaturityE8sEquivalentBuckets = maturityE8sEquivalentBuckets;
			this.StakedMaturityE8sEquivalentBuckets = stakedMaturityE8sEquivalentBuckets;
			this.VotingPowerBuckets = votingPowerBuckets;
			this.DecidingVotingPowerBuckets = decidingVotingPowerBuckets;
			this.PotentialVotingPowerBuckets = potentialVotingPowerBuckets;
		}

		public NeuronSubsetMetrics()
		{
		}
	}
}