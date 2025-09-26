using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using PublicKey = System.Collections.Generic.List<System.Byte>;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class Delegation
	{
		[CandidName("pubkey")]
		public PublicKey Pubkey { get; set; }

		[CandidName("expiration")]
		public Timestamp Expiration { get; set; }

		[CandidName("targets")]
		public OptionalValue<List<Principal>> Targets { get; set; }

		public Delegation(PublicKey pubkey, Timestamp expiration, OptionalValue<List<Principal>> targets)
		{
			this.Pubkey = pubkey;
			this.Expiration = expiration;
			this.Targets = targets;
		}

		public Delegation()
		{
		}
	}
}