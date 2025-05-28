using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class RewardToAccount
	{
		[CandidName("to_account")]
		public OptionalValue<AccountIdentifier> ToAccount { get; set; }

		public RewardToAccount(OptionalValue<AccountIdentifier> toAccount)
		{
			this.ToAccount = toAccount;
		}

		public RewardToAccount()
		{
		}
	}
}