using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class UpdateCanisterSettings
	{
		[CandidName("canister_id")]
		public OptionalValue<Principal> CanisterId { get; set; }

		[CandidName("settings")]
		public OptionalValue<CanisterSettings> Settings { get; set; }

		public UpdateCanisterSettings(OptionalValue<Principal> canisterId, OptionalValue<CanisterSettings> settings)
		{
			this.CanisterId = canisterId;
			this.Settings = settings;
		}

		public UpdateCanisterSettings()
		{
		}
	}
}