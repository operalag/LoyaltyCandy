using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Controllers
	{
		[CandidName("controllers")]
		public List<Principal> Controllers_ { get; set; }

		public Controllers(List<Principal> controllers)
		{
			this.Controllers_ = controllers;
		}

		public Controllers()
		{
		}
	}
}