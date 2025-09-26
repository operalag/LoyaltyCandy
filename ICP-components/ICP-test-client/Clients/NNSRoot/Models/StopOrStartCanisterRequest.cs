using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRoot.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class StopOrStartCanisterRequest
	{
		[CandidName("action")]
		public CanisterAction Action { get; set; }

		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		public StopOrStartCanisterRequest(CanisterAction action, Principal canisterId)
		{
			this.Action = action;
			this.CanisterId = canisterId;
		}

		public StopOrStartCanisterRequest()
		{
		}
	}
}