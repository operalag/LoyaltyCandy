using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class CanisterSummary
	{
		[CandidName("status")]
		public OptionalValue<CanisterStatusResultV2> Status { get; set; }

		[CandidName("canister_id")]
		public OptionalValue<Principal> CanisterId { get; set; }

		public CanisterSummary(OptionalValue<CanisterStatusResultV2> status, OptionalValue<Principal> canisterId)
		{
			this.Status = status;
			this.CanisterId = canisterId;
		}

		public CanisterSummary()
		{
		}
	}
}