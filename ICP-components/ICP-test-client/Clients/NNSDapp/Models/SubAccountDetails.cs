using EdjCase.ICP.Candid.Mapping;
using AccountIdentifier = System.String;
using SubAccount = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class SubAccountDetails
	{
		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("sub_account")]
		public SubAccount SubAccount { get; set; }

		[CandidName("account_identifier")]
		public AccountIdentifier AccountIdentifier { get; set; }

		public SubAccountDetails(string name, SubAccount subAccount, AccountIdentifier accountIdentifier)
		{
			this.Name = name;
			this.SubAccount = subAccount;
			this.AccountIdentifier = accountIdentifier;
		}

		public SubAccountDetails()
		{
		}
	}
}