using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class DetachCanisterRequest
	{
		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		public DetachCanisterRequest(Principal canisterId)
		{
			this.CanisterId = canisterId;
		}

		public DetachCanisterRequest()
		{
		}
	}
}