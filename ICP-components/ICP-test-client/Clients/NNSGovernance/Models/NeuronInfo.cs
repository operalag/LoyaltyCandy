using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronInfo
	{
		[CandidName("dissolve_delay_seconds")]
		public ulong DissolveDelaySeconds { get; set; }

		[CandidName("recent_ballots")]
		public List<BallotInfo> RecentBallots { get; set; }

		[CandidName("neuron_type")]
		public OptionalValue<int> NeuronType { get; set; }

		[CandidName("created_timestamp_seconds")]
		public ulong CreatedTimestampSeconds { get; set; }

		[CandidName("state")]
		public int State { get; set; }

		[CandidName("stake_e8s")]
		public ulong StakeE8s { get; set; }

		[CandidName("joined_community_fund_timestamp_seconds")]
		public OptionalValue<ulong> JoinedCommunityFundTimestampSeconds { get; set; }

		[CandidName("retrieved_at_timestamp_seconds")]
		public ulong RetrievedAtTimestampSeconds { get; set; }

		[CandidName("visibility")]
		public OptionalValue<int> Visibility { get; set; }

		[CandidName("known_neuron_data")]
		public OptionalValue<KnownNeuronData> KnownNeuronData { get; set; }

		[CandidName("age_seconds")]
		public ulong AgeSeconds { get; set; }

		[CandidName("voting_power_refreshed_timestamp_seconds")]
		public OptionalValue<ulong> VotingPowerRefreshedTimestampSeconds { get; set; }

		[CandidName("voting_power")]
		public ulong VotingPower { get; set; }

		[CandidName("deciding_voting_power")]
		public OptionalValue<ulong> DecidingVotingPower { get; set; }

		[CandidName("potential_voting_power")]
		public OptionalValue<ulong> PotentialVotingPower { get; set; }

		public NeuronInfo(ulong dissolveDelaySeconds, List<BallotInfo> recentBallots, OptionalValue<int> neuronType, ulong createdTimestampSeconds, int state, ulong stakeE8s, OptionalValue<ulong> joinedCommunityFundTimestampSeconds, ulong retrievedAtTimestampSeconds, OptionalValue<int> visibility, OptionalValue<KnownNeuronData> knownNeuronData, ulong ageSeconds, OptionalValue<ulong> votingPowerRefreshedTimestampSeconds, ulong votingPower, OptionalValue<ulong> decidingVotingPower, OptionalValue<ulong> potentialVotingPower)
		{
			this.DissolveDelaySeconds = dissolveDelaySeconds;
			this.RecentBallots = recentBallots;
			this.NeuronType = neuronType;
			this.CreatedTimestampSeconds = createdTimestampSeconds;
			this.State = state;
			this.StakeE8s = stakeE8s;
			this.JoinedCommunityFundTimestampSeconds = joinedCommunityFundTimestampSeconds;
			this.RetrievedAtTimestampSeconds = retrievedAtTimestampSeconds;
			this.Visibility = visibility;
			this.KnownNeuronData = knownNeuronData;
			this.AgeSeconds = ageSeconds;
			this.VotingPowerRefreshedTimestampSeconds = votingPowerRefreshedTimestampSeconds;
			this.VotingPower = votingPower;
			this.DecidingVotingPower = decidingVotingPower;
			this.PotentialVotingPower = potentialVotingPower;
		}

		public NeuronInfo()
		{
		}
	}
}