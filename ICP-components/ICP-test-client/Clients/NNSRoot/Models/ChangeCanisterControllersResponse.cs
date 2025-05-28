using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRoot.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class ChangeCanisterControllersResponse
	{
		[CandidName("change_canister_controllers_result")]
		public ChangeCanisterControllersResult ChangeCanisterControllersResult { get; set; }

		public ChangeCanisterControllersResponse(ChangeCanisterControllersResult changeCanisterControllersResult)
		{
			this.ChangeCanisterControllersResult = changeCanisterControllersResult;
		}

		public ChangeCanisterControllersResponse()
		{
		}
	}
}