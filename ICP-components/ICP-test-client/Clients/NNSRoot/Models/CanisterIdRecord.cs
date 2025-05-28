using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class CanisterIdRecord
	{
		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		public CanisterIdRecord(Principal canisterId)
		{
			this.CanisterId = canisterId;
		}

		public CanisterIdRecord()
		{
		}
	}
}