using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Followees
	{
		[CandidName("followees")]
		public List<NeuronId> Followees_ { get; set; }

		public Followees(List<NeuronId> followees)
		{
			this.Followees_ = followees;
		}

		public Followees()
		{
		}
	}
}