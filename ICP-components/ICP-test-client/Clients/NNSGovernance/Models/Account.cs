using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Account
	{
		[CandidName("owner")]
		public OptionalValue<Principal> Owner { get; set; }

		[CandidName("subaccount")]
		public OptionalValue<List<byte>> Subaccount { get; set; }

		public Account(OptionalValue<Principal> owner, OptionalValue<List<byte>> subaccount)
		{
			this.Owner = owner;
			this.Subaccount = subaccount;
		}

		public Account()
		{
		}
	}
}