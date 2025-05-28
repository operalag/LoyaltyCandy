using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class Histogram
	{
		[CandidName("accounts_count")]
		public ulong AccountsCount { get; set; }

		[CandidName("default_account_transactions")]
		public Dictionary<uint, ulong> DefaultAccountTransactions { get; set; }

		[CandidName("sub_accounts")]
		public Dictionary<uint, ulong> SubAccounts { get; set; }

		[CandidName("sub_account_transactions")]
		public Dictionary<uint, ulong> SubAccountTransactions { get; set; }

		[CandidName("total_sub_account_transactions")]
		public Dictionary<uint, ulong> TotalSubAccountTransactions { get; set; }

		[CandidName("hardware_wallet_accounts")]
		public Dictionary<uint, ulong> HardwareWalletAccounts { get; set; }

		[CandidName("hardware_wallet_transactions")]
		public Dictionary<uint, ulong> HardwareWalletTransactions { get; set; }

		[CandidName("total_hardware_wallet_transactions")]
		public Dictionary<uint, ulong> TotalHardwareWalletTransactions { get; set; }

		[CandidName("canisters")]
		public Dictionary<uint, ulong> Canisters { get; set; }

		public Histogram(ulong accountsCount, Dictionary<uint, ulong> defaultAccountTransactions, Dictionary<uint, ulong> subAccounts, Dictionary<uint, ulong> subAccountTransactions, Dictionary<uint, ulong> totalSubAccountTransactions, Dictionary<uint, ulong> hardwareWalletAccounts, Dictionary<uint, ulong> hardwareWalletTransactions, Dictionary<uint, ulong> totalHardwareWalletTransactions, Dictionary<uint, ulong> canisters)
		{
			this.AccountsCount = accountsCount;
			this.DefaultAccountTransactions = defaultAccountTransactions;
			this.SubAccounts = subAccounts;
			this.SubAccountTransactions = subAccountTransactions;
			this.TotalSubAccountTransactions = totalSubAccountTransactions;
			this.HardwareWalletAccounts = hardwareWalletAccounts;
			this.HardwareWalletTransactions = hardwareWalletTransactions;
			this.TotalHardwareWalletTransactions = totalHardwareWalletTransactions;
			this.Canisters = canisters;
		}

		public Histogram()
		{
		}
	}
}