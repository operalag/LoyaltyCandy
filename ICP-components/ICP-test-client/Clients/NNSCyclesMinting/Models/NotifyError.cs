using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using System;
using EdjCase.ICP.Candid.Models;
using BlockIndex = System.UInt64;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class NotifyError
	{
		[VariantTagProperty]
		public NotifyErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public NotifyError(NotifyErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected NotifyError()
		{
		}

		public static NotifyError Refunded(NotifyError.RefundedInfo info)
		{
			return new NotifyError(NotifyErrorTag.Refunded, info);
		}

		public static NotifyError Processing()
		{
			return new NotifyError(NotifyErrorTag.Processing, null);
		}

		public static NotifyError TransactionTooOld(BlockIndex info)
		{
			return new NotifyError(NotifyErrorTag.TransactionTooOld, info);
		}

		public static NotifyError InvalidTransaction(string info)
		{
			return new NotifyError(NotifyErrorTag.InvalidTransaction, info);
		}

		public static NotifyError Other(NotifyError.OtherInfo info)
		{
			return new NotifyError(NotifyErrorTag.Other, info);
		}

		public NotifyError.RefundedInfo AsRefunded()
		{
			this.ValidateTag(NotifyErrorTag.Refunded);
			return (NotifyError.RefundedInfo)this.Value!;
		}

		public BlockIndex AsTransactionTooOld()
		{
			this.ValidateTag(NotifyErrorTag.TransactionTooOld);
			return (BlockIndex)this.Value!;
		}

		public string AsInvalidTransaction()
		{
			this.ValidateTag(NotifyErrorTag.InvalidTransaction);
			return (string)this.Value!;
		}

		public NotifyError.OtherInfo AsOther()
		{
			this.ValidateTag(NotifyErrorTag.Other);
			return (NotifyError.OtherInfo)this.Value!;
		}

		private void ValidateTag(NotifyErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class RefundedInfo
		{
			[CandidName("reason")]
			public string Reason { get; set; }

			[CandidName("block_index")]
			public NotifyError.RefundedInfo.BlockIndexInfo BlockIndex { get; set; }

			public RefundedInfo(string reason, NotifyError.RefundedInfo.BlockIndexInfo blockIndex)
			{
				this.Reason = reason;
				this.BlockIndex = blockIndex;
			}

			public RefundedInfo()
			{
			}

			public class BlockIndexInfo : OptionalValue<BlockIndex>
			{
				public BlockIndexInfo()
				{
				}

				public BlockIndexInfo(BlockIndex value) : base(value)
				{
				}
			}
		}

		public class OtherInfo
		{
			[CandidName("error_code")]
			public ulong ErrorCode { get; set; }

			[CandidName("error_message")]
			public string ErrorMessage { get; set; }

			public OtherInfo(ulong errorCode, string errorMessage)
			{
				this.ErrorCode = errorCode;
				this.ErrorMessage = errorMessage;
			}

			public OtherInfo()
			{
			}
		}
	}

	public enum NotifyErrorTag
	{
		Refunded,
		Processing,
		TransactionTooOld,
		InvalidTransaction,
		Other
	}
}