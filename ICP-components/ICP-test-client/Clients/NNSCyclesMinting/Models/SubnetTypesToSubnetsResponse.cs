using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class SubnetTypesToSubnetsResponse
	{
		[CandidName("data")]
		public Dictionary<string, List<Principal>> Data { get; set; }

		public SubnetTypesToSubnetsResponse(Dictionary<string, List<Principal>> data)
		{
			this.Data = data;
		}

		public SubnetTypesToSubnetsResponse()
		{
		}
	}
}