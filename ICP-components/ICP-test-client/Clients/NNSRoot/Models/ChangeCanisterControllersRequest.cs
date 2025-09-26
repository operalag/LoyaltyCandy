using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class ChangeCanisterControllersRequest
	{
		[CandidName("target_canister_id")]
		public Principal TargetCanisterId { get; set; }

		[CandidName("new_controllers")]
		public List<Principal> NewControllers { get; set; }

		public ChangeCanisterControllersRequest(Principal targetCanisterId, List<Principal> newControllers)
		{
			this.TargetCanisterId = targetCanisterId;
			this.NewControllers = newControllers;
		}

		public ChangeCanisterControllersRequest()
		{
		}
	}
}