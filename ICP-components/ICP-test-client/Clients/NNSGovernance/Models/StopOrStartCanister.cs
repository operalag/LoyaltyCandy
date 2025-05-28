using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class StopOrStartCanister
	{
		[CandidName("action")]
		public OptionalValue<int> Action { get; set; }

		[CandidName("canister_id")]
		public OptionalValue<Principal> CanisterId { get; set; }

		public StopOrStartCanister(OptionalValue<int> action, OptionalValue<Principal> canisterId)
		{
			this.Action = action;
			this.CanisterId = canisterId;
		}

		public StopOrStartCanister()
		{
		}
	}
}