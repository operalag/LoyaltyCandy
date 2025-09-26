using EdjCase.ICP.Candid.Mapping;
using TextAccountIdentifier = System.String;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class AccountBalanceArgsDfx
	{
		[CandidName("account")]
		public TextAccountIdentifier Account { get; set; }

		public AccountBalanceArgsDfx(TextAccountIdentifier account)
		{
			this.Account = account;
		}

		public AccountBalanceArgsDfx()
		{
		}
	}
}