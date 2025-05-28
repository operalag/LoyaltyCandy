using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class RestoreAgingNeuronGroup
	{
		[CandidName("count")]
		public OptionalValue<ulong> Count { get; set; }

		[CandidName("previous_total_stake_e8s")]
		public OptionalValue<ulong> PreviousTotalStakeE8s { get; set; }

		[CandidName("current_total_stake_e8s")]
		public OptionalValue<ulong> CurrentTotalStakeE8s { get; set; }

		[CandidName("group_type")]
		public int GroupType { get; set; }

		public RestoreAgingNeuronGroup(OptionalValue<ulong> count, OptionalValue<ulong> previousTotalStakeE8s, OptionalValue<ulong> currentTotalStakeE8s, int groupType)
		{
			this.Count = count;
			this.PreviousTotalStakeE8s = previousTotalStakeE8s;
			this.CurrentTotalStakeE8s = currentTotalStakeE8s;
			this.GroupType = groupType;
		}

		public RestoreAgingNeuronGroup()
		{
		}
	}
}