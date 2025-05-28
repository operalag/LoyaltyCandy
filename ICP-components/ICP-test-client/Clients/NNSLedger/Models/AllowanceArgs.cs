using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class AllowanceArgs
	{
		[CandidName("account")]
		public Account Account { get; set; }

		[CandidName("spender")]
		public Account Spender { get; set; }

		public AllowanceArgs(Account account, Account spender)
		{
			this.Account = account;
			this.Spender = spender;
		}

		public AllowanceArgs()
		{
		}
	}
}