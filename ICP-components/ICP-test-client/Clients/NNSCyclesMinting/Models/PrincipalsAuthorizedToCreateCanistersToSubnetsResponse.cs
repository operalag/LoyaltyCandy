using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class PrincipalsAuthorizedToCreateCanistersToSubnetsResponse
	{
		[CandidName("data")]
		public Dictionary<Principal, List<Principal>> Data { get; set; }

		public PrincipalsAuthorizedToCreateCanistersToSubnetsResponse(Dictionary<Principal, List<Principal>> data)
		{
			this.Data = data;
		}

		public PrincipalsAuthorizedToCreateCanistersToSubnetsResponse()
		{
		}
	}
}