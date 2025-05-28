using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SetSnsTokenSwapOpenTimeWindow
	{
		[CandidName("request")]
		public OptionalValue<SetOpenTimeWindowRequest> Request { get; set; }

		[CandidName("swap_canister_id")]
		public OptionalValue<Principal> SwapCanisterId { get; set; }

		public SetSnsTokenSwapOpenTimeWindow(OptionalValue<SetOpenTimeWindowRequest> request, OptionalValue<Principal> swapCanisterId)
		{
			this.Request = request;
			this.SwapCanisterId = swapCanisterId;
		}

		public SetSnsTokenSwapOpenTimeWindow()
		{
		}
	}
}