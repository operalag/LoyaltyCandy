using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class VotingPowerEconomics
	{
		[CandidName("start_reducing_voting_power_after_seconds")]
		public OptionalValue<ulong> StartReducingVotingPowerAfterSeconds { get; set; }

		[CandidName("clear_following_after_seconds")]
		public OptionalValue<ulong> ClearFollowingAfterSeconds { get; set; }

		[CandidName("neuron_minimum_dissolve_delay_to_vote_seconds")]
		public OptionalValue<ulong> NeuronMinimumDissolveDelayToVoteSeconds { get; set; }

		public VotingPowerEconomics(OptionalValue<ulong> startReducingVotingPowerAfterSeconds, OptionalValue<ulong> clearFollowingAfterSeconds, OptionalValue<ulong> neuronMinimumDissolveDelayToVoteSeconds)
		{
			this.StartReducingVotingPowerAfterSeconds = startReducingVotingPowerAfterSeconds;
			this.ClearFollowingAfterSeconds = clearFollowingAfterSeconds;
			this.NeuronMinimumDissolveDelayToVoteSeconds = neuronMinimumDissolveDelayToVoteSeconds;
		}

		public VotingPowerEconomics()
		{
		}
	}
}