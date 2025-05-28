using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class RenameCanisterRequest
	{
		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		public RenameCanisterRequest(string name, Principal canisterId)
		{
			this.Name = name;
			this.CanisterId = canisterId;
		}

		public RenameCanisterRequest()
		{
		}
	}
}