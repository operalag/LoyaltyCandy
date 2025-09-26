using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.InternetIdentity.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class InternetIdentityInit
	{
		[CandidName("assigned_user_number_range")]
		public OptionalValue<(ulong, ulong)> AssignedUserNumberRange { get; set; }

		[CandidName("archive_config")]
		public OptionalValue<ArchiveConfig> ArchiveConfig { get; set; }

		[CandidName("canister_creation_cycles_cost")]
		public OptionalValue<ulong> CanisterCreationCyclesCost { get; set; }

		[CandidName("register_rate_limit")]
		public OptionalValue<RateLimitConfig> RegisterRateLimit { get; set; }

		[CandidName("max_inflight_captchas")]
		public OptionalValue<ulong> MaxInflightCaptchas { get; set; }

		public InternetIdentityInit(OptionalValue<(ulong, ulong)> assignedUserNumberRange, OptionalValue<ArchiveConfig> archiveConfig, OptionalValue<ulong> canisterCreationCyclesCost, OptionalValue<RateLimitConfig> registerRateLimit, OptionalValue<ulong> maxInflightCaptchas)
		{
			this.AssignedUserNumberRange = assignedUserNumberRange;
			this.ArchiveConfig = archiveConfig;
			this.CanisterCreationCyclesCost = canisterCreationCyclesCost;
			this.RegisterRateLimit = registerRateLimit;
			this.MaxInflightCaptchas = maxInflightCaptchas;
		}

		public InternetIdentityInit()
		{
		}
	}
}