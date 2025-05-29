using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using System;
using EdjCase.ICP.Candid.Models;
using Icrc1BlockIndex = EdjCase.ICP.Candid.Models.UnboundedUInt;
using Icrc1Tokens = EdjCase.ICP.Candid.Models.UnboundedUInt;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class ApproveError
	{
		[VariantTagProperty]
		public ApproveErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public ApproveError(ApproveErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected ApproveError()
		{
		}

		public static ApproveError BadFee(ApproveError.BadFeeInfo info)
		{
			return new ApproveError(ApproveErrorTag.BadFee, info);
		}

		public static ApproveError InsufficientFunds(ApproveError.InsufficientFundsInfo info)
		{
			return new ApproveError(ApproveErrorTag.InsufficientFunds, info);
		}

		public static ApproveError AllowanceChanged(ApproveError.AllowanceChangedInfo info)
		{
			return new ApproveError(ApproveErrorTag.AllowanceChanged, info);
		}

		public static ApproveError Expired(ApproveError.ExpiredInfo info)
		{
			return new ApproveError(ApproveErrorTag.Expired, info);
		}

		public static ApproveError TooOld()
		{
			return new ApproveError(ApproveErrorTag.TooOld, null);
		}

		public static ApproveError CreatedInFuture(ApproveError.CreatedInFutureInfo info)
		{
			return new ApproveError(ApproveErrorTag.CreatedInFuture, info);
		}

		public static ApproveError Duplicate(ApproveError.DuplicateInfo info)
		{
			return new ApproveError(ApproveErrorTag.Duplicate, info);
		}

		public static ApproveError TemporarilyUnavailable()
		{
			return new ApproveError(ApproveErrorTag.TemporarilyUnavailable, null);
		}

		public static ApproveError GenericError(ApproveError.GenericErrorInfo info)
		{
			return new ApproveError(ApproveErrorTag.GenericError, info);
		}

		public ApproveError.BadFeeInfo AsBadFee()
		{
			this.ValidateTag(ApproveErrorTag.BadFee);
			return (ApproveError.BadFeeInfo)this.Value!;
		}

		public ApproveError.InsufficientFundsInfo AsInsufficientFunds()
		{
			this.ValidateTag(ApproveErrorTag.InsufficientFunds);
			return (ApproveError.InsufficientFundsInfo)this.Value!;
		}

		public ApproveError.AllowanceChangedInfo AsAllowanceChanged()
		{
			this.ValidateTag(ApproveErrorTag.AllowanceChanged);
			return (ApproveError.AllowanceChangedInfo)this.Value!;
		}

		public ApproveError.ExpiredInfo AsExpired()
		{
			this.ValidateTag(ApproveErrorTag.Expired);
			return (ApproveError.ExpiredInfo)this.Value!;
		}

		public ApproveError.CreatedInFutureInfo AsCreatedInFuture()
		{
			this.ValidateTag(ApproveErrorTag.CreatedInFuture);
			return (ApproveError.CreatedInFutureInfo)this.Value!;
		}

		public ApproveError.DuplicateInfo AsDuplicate()
		{
			this.ValidateTag(ApproveErrorTag.Duplicate);
			return (ApproveError.DuplicateInfo)this.Value!;
		}

		public ApproveError.GenericErrorInfo AsGenericError()
		{
			this.ValidateTag(ApproveErrorTag.GenericError);
			return (ApproveError.GenericErrorInfo)this.Value!;
		}

		private void ValidateTag(ApproveErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class BadFeeInfo
		{
			[CandidName("expected_fee")]
			public Icrc1Tokens ExpectedFee { get; set; }

			public BadFeeInfo(Icrc1Tokens expectedFee)
			{
				this.ExpectedFee = expectedFee;
			}

			public BadFeeInfo()
			{
			}
		}

		public class InsufficientFundsInfo
		{
			[CandidName("balance")]
			public Icrc1Tokens Balance { get; set; }

			public InsufficientFundsInfo(Icrc1Tokens balance)
			{
				this.Balance = balance;
			}

			public InsufficientFundsInfo()
			{
			}
		}

		public class AllowanceChangedInfo
		{
			[CandidName("current_allowance")]
			public Icrc1Tokens CurrentAllowance { get; set; }

			public AllowanceChangedInfo(Icrc1Tokens currentAllowance)
			{
				this.CurrentAllowance = currentAllowance;
			}

			public AllowanceChangedInfo()
			{
			}
		}

		public class ExpiredInfo
		{
			[CandidName("ledger_time")]
			public ulong LedgerTime { get; set; }

			public ExpiredInfo(ulong ledgerTime)
			{
				this.LedgerTime = ledgerTime;
			}

			public ExpiredInfo()
			{
			}
		}

		public class CreatedInFutureInfo
		{
			[CandidName("ledger_time")]
			public ulong LedgerTime { get; set; }

			public CreatedInFutureInfo(ulong ledgerTime)
			{
				this.LedgerTime = ledgerTime;
			}

			public CreatedInFutureInfo()
			{
			}
		}

		public class DuplicateInfo
		{
			[CandidName("duplicate_of")]
			public Icrc1BlockIndex DuplicateOf { get; set; }

			public DuplicateInfo(Icrc1BlockIndex duplicateOf)
			{
				this.DuplicateOf = duplicateOf;
			}

			public DuplicateInfo()
			{
			}
		}

		public class GenericErrorInfo
		{
			[CandidName("error_code")]
			public UnboundedUInt ErrorCode { get; set; }

			[CandidName("message")]
			public string Message { get; set; }

			public GenericErrorInfo(UnboundedUInt errorCode, string message)
			{
				this.ErrorCode = errorCode;
				this.Message = message;
			}

			public GenericErrorInfo()
			{
			}
		}
	}

	public enum ApproveErrorTag
	{
		BadFee,
		InsufficientFunds,
		AllowanceChanged,
		Expired,
		TooOld,
		CreatedInFuture,
		Duplicate,
		TemporarilyUnavailable,
		GenericError
	}
}