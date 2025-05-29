using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class SignedDelegation
	{
		[CandidName("delegation")]
		public Delegation Delegation { get; set; }

		[CandidName("signature")]
		public List<byte> Signature { get; set; }

		public SignedDelegation(Delegation delegation, List<byte> signature)
		{
			this.Delegation = delegation;
			this.Signature = signature;
		}

		public SignedDelegation()
		{
		}
	}
}