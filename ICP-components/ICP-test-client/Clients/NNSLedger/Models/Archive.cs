using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Archive
	{
		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		public Archive(Principal canisterId)
		{
			this.CanisterId = canisterId;
		}

		public Archive()
		{
		}
	}
}