using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class GetSubnetForCanisterRequest
	{
		[CandidName("principal")]
		public OptionalValue<Principal> Principal { get; set; }

		public GetSubnetForCanisterRequest(OptionalValue<Principal> principal)
		{
			this.Principal = principal;
		}

		public GetSubnetForCanisterRequest()
		{
		}
	}
}