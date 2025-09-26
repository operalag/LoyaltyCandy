using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using System;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using AccountIdentifier = System.Collections.Generic.List<System.Byte>;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class Operation
	{
		[VariantTagProperty]
		public OperationTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Operation(OperationTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Operation()
		{
		}

		public static Operation Mint(Operation.MintInfo info)
		{
			return new Operation(OperationTag.Mint, info);
		}

		public static Operation Burn(Operation.BurnInfo info)
		{
			return new Operation(OperationTag.Burn, info);
		}

		public static Operation Transfer(Operation.TransferInfo info)
		{
			return new Operation(OperationTag.Transfer, info);
		}

		public static Operation Approve(Operation.ApproveInfo info)
		{
			return new Operation(OperationTag.Approve, info);
		}

		public Operation.MintInfo AsMint()
		{
			this.ValidateTag(OperationTag.Mint);
			return (Operation.MintInfo)this.Value!;
		}

		public Operation.BurnInfo AsBurn()
		{
			this.ValidateTag(OperationTag.Burn);
			return (Operation.BurnInfo)this.Value!;
		}

		public Operation.TransferInfo AsTransfer()
		{
			this.ValidateTag(OperationTag.Transfer);
			return (Operation.TransferInfo)this.Value!;
		}

		public Operation.ApproveInfo AsApprove()
		{
			this.ValidateTag(OperationTag.Approve);
			return (Operation.ApproveInfo)this.Value!;
		}

		private void ValidateTag(OperationTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class MintInfo
		{
			[CandidName("to")]
			public AccountIdentifier To { get; set; }

			[CandidName("amount")]
			public Tokens Amount { get; set; }

			public MintInfo(AccountIdentifier to, Tokens amount)
			{
				this.To = to;
				this.Amount = amount;
			}

			public MintInfo()
			{
			}
		}

		public class BurnInfo
		{
			[CandidName("from")]
			public AccountIdentifier From { get; set; }

			[CandidName("spender")]
			public Operation.BurnInfo.SpenderInfo Spender { get; set; }

			[CandidName("amount")]
			public Tokens Amount { get; set; }

			public BurnInfo(AccountIdentifier from, Operation.BurnInfo.SpenderInfo spender, Tokens amount)
			{
				this.From = from;
				this.Spender = spender;
				this.Amount = amount;
			}

			public BurnInfo()
			{
			}

			public class SpenderInfo : OptionalValue<AccountIdentifier>
			{
				public SpenderInfo()
				{
				}

				public SpenderInfo(AccountIdentifier value) : base(value)
				{
				}
			}
		}

		public class TransferInfo
		{
			[CandidName("from")]
			public AccountIdentifier From { get; set; }

			[CandidName("to")]
			public AccountIdentifier To { get; set; }

			[CandidName("amount")]
			public Tokens Amount { get; set; }

			[CandidName("fee")]
			public Tokens Fee { get; set; }

			[CandidName("spender")]
			public OptionalValue<List<byte>> Spender { get; set; }

			public TransferInfo(AccountIdentifier from, AccountIdentifier to, Tokens amount, Tokens fee, OptionalValue<List<byte>> spender)
			{
				this.From = from;
				this.To = to;
				this.Amount = amount;
				this.Fee = fee;
				this.Spender = spender;
			}

			public TransferInfo()
			{
			}
		}

		public class ApproveInfo
		{
			[CandidName("from")]
			public AccountIdentifier From { get; set; }

			[CandidName("spender")]
			public AccountIdentifier Spender { get; set; }

			[CandidName("allowance_e8s")]
			public UnboundedInt AllowanceE8s { get; set; }

			[CandidName("allowance")]
			public Tokens Allowance { get; set; }

			[CandidName("fee")]
			public Tokens Fee { get; set; }

			[CandidName("expires_at")]
			public OptionalValue<TimeStamp> ExpiresAt { get; set; }

			[CandidName("expected_allowance")]
			public OptionalValue<Tokens> ExpectedAllowance { get; set; }

			public ApproveInfo(AccountIdentifier from, AccountIdentifier spender, UnboundedInt allowanceE8s, Tokens allowance, Tokens fee, OptionalValue<TimeStamp> expiresAt, OptionalValue<Tokens> expectedAllowance)
			{
				this.From = from;
				this.Spender = spender;
				this.AllowanceE8s = allowanceE8s;
				this.Allowance = allowance;
				this.Fee = fee;
				this.ExpiresAt = expiresAt;
				this.ExpectedAllowance = expectedAllowance;
			}

			public ApproveInfo()
			{
			}
		}
	}

	public enum OperationTag
	{
		Mint,
		Burn,
		Transfer,
		Approve
	}
}