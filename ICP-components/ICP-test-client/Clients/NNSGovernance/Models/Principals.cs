using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Principals
	{
		[CandidName("principals")]
		public List<Principal> Principals_ { get; set; }

		public Principals(List<Principal> principals)
		{
			this.Principals_ = principals;
		}

		public Principals()
		{
		}
	}
}