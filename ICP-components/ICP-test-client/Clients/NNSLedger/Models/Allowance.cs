using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using EdjCase.ICP.Candid.Models;
using Icrc1Timestamp = System.UInt64;
using Icrc1Tokens = EdjCase.ICP.Candid.Models.UnboundedUInt;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Allowance
	{
		[CandidName("allowance")]
		public Icrc1Tokens Allowance_ { get; set; }

		[CandidName("expires_at")]
		public Allowance.ExpiresAtInfo ExpiresAt { get; set; }

		public Allowance(Icrc1Tokens allowance, Allowance.ExpiresAtInfo expiresAt)
		{
			this.Allowance_ = allowance;
			this.ExpiresAt = expiresAt;
		}

		public Allowance()
		{
		}

		public class ExpiresAtInfo : OptionalValue<Icrc1Timestamp>
		{
			public ExpiresAtInfo()
			{
			}

			public ExpiresAtInfo(Icrc1Timestamp value) : base(value)
			{
			}
		}
	}
}