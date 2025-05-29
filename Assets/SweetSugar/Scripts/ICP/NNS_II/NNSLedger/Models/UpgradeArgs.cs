using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class UpgradeArgs
	{
		[CandidName("icrc1_minting_account")]
		public OptionalValue<Account> Icrc1MintingAccount { get; set; }

		[CandidName("feature_flags")]
		public OptionalValue<FeatureFlags> FeatureFlags { get; set; }

		public UpgradeArgs(OptionalValue<Account> icrc1MintingAccount, OptionalValue<FeatureFlags> featureFlags)
		{
			this.Icrc1MintingAccount = icrc1MintingAccount;
			this.FeatureFlags = featureFlags;
		}

		public UpgradeArgs()
		{
		}
	}
}