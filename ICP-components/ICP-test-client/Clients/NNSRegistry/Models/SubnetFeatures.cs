using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class SubnetFeatures
	{
		[CandidName("canister_sandboxing")]
		public bool CanisterSandboxing { get; set; }

		[CandidName("http_requests")]
		public bool HttpRequests { get; set; }

		[CandidName("sev_enabled")]
		public OptionalValue<bool> SevEnabled { get; set; }

		public SubnetFeatures(bool canisterSandboxing, bool httpRequests, OptionalValue<bool> sevEnabled)
		{
			this.CanisterSandboxing = canisterSandboxing;
			this.HttpRequests = httpRequests;
			this.SevEnabled = sevEnabled;
		}

		public SubnetFeatures()
		{
		}
	}
}