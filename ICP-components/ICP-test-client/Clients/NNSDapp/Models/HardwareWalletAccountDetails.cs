using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using AccountIdentifier = System.String;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class HardwareWalletAccountDetails
	{
		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("principal")]
		public Principal Principal { get; set; }

		[CandidName("account_identifier")]
		public AccountIdentifier AccountIdentifier { get; set; }

		public HardwareWalletAccountDetails(string name, Principal principal, AccountIdentifier accountIdentifier)
		{
			this.Name = name;
			this.Principal = principal;
			this.AccountIdentifier = accountIdentifier;
		}

		public HardwareWalletAccountDetails()
		{
		}
	}
}