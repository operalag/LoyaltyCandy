using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class NodeOperatorPrincipals
	{
		[CandidName("principals")]
		public List<Principal> Principals { get; set; }

		public NodeOperatorPrincipals(List<Principal> principals)
		{
			this.Principals = principals;
		}

		public NodeOperatorPrincipals()
		{
		}
	}
}