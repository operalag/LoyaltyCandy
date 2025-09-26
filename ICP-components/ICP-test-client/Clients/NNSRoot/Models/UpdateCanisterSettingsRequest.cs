using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRoot.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class UpdateCanisterSettingsRequest
	{
		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		[CandidName("settings")]
		public CanisterSettings Settings { get; set; }

		public UpdateCanisterSettingsRequest(Principal canisterId, CanisterSettings settings)
		{
			this.CanisterId = canisterId;
			this.Settings = settings;
		}

		public UpdateCanisterSettingsRequest()
		{
		}
	}
}