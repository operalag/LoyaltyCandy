using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Follow
	{
		[CandidName("topic")]
		public int Topic { get; set; }

		[CandidName("followees")]
		public List<NeuronId> Followees { get; set; }

		public Follow(int topic, List<NeuronId> followees)
		{
			this.Topic = topic;
			this.Followees = followees;
		}

		public Follow()
		{
		}
	}
}