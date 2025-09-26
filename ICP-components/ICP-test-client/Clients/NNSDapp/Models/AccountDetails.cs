using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSDapp.Models;
using AccountIdentifier = System.String;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class AccountDetails
	{
		[CandidName("principal")]
		public Principal Principal { get; set; }

		[CandidName("account_identifier")]
		public AccountIdentifier AccountIdentifier { get; set; }

		[CandidName("sub_accounts")]
		public List<SubAccountDetails> SubAccounts { get; set; }

		[CandidName("hardware_wallet_accounts")]
		public List<HardwareWalletAccountDetails> HardwareWalletAccounts { get; set; }

		public AccountDetails(Principal principal, AccountIdentifier accountIdentifier, List<SubAccountDetails> subAccounts, List<HardwareWalletAccountDetails> hardwareWalletAccounts)
		{
			this.Principal = principal;
			this.AccountIdentifier = accountIdentifier;
			this.SubAccounts = subAccounts;
			this.HardwareWalletAccounts = hardwareWalletAccounts;
		}

		public AccountDetails()
		{
		}
	}
}