using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class RestoreAgingSummary
	{
		[CandidName("groups")]
		public List<RestoreAgingNeuronGroup> Groups { get; set; }

		[CandidName("timestamp_seconds")]
		public OptionalValue<ulong> TimestampSeconds { get; set; }

		public RestoreAgingSummary(List<RestoreAgingNeuronGroup> groups, OptionalValue<ulong> timestampSeconds)
		{
			this.Groups = groups;
			this.TimestampSeconds = timestampSeconds;
		}

		public RestoreAgingSummary()
		{
		}
	}
}