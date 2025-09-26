using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class RegisterHardwareWalletRequest
	{
		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("principal")]
		public Principal Principal { get; set; }

		public RegisterHardwareWalletRequest(string name, Principal principal)
		{
			this.Name = name;
			this.Principal = principal;
		}

		public RegisterHardwareWalletRequest()
		{
		}
	}
}