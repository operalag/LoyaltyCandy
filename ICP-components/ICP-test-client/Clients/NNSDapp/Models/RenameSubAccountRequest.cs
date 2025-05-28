using EdjCase.ICP.Candid.Mapping;
using AccountIdentifier = System.String;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class RenameSubAccountRequest
	{
		[CandidName("account_identifier")]
		public AccountIdentifier AccountIdentifier { get; set; }

		[CandidName("new_name")]
		public string NewName { get; set; }

		public RenameSubAccountRequest(AccountIdentifier accountIdentifier, string newName)
		{
			this.AccountIdentifier = accountIdentifier;
			this.NewName = newName;
		}

		public RenameSubAccountRequest()
		{
		}
	}
}