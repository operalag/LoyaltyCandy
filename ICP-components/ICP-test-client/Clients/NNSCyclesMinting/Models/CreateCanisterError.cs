using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using System;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class CreateCanisterError
	{
		[VariantTagProperty]
		public CreateCanisterErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public CreateCanisterError(CreateCanisterErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected CreateCanisterError()
		{
		}

		public static CreateCanisterError Refunded(CreateCanisterError.RefundedInfo info)
		{
			return new CreateCanisterError(CreateCanisterErrorTag.Refunded, info);
		}

		public CreateCanisterError.RefundedInfo AsRefunded()
		{
			this.ValidateTag(CreateCanisterErrorTag.Refunded);
			return (CreateCanisterError.RefundedInfo)this.Value!;
		}

		private void ValidateTag(CreateCanisterErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class RefundedInfo
		{
			[CandidName("refund_amount")]
			public UnboundedUInt RefundAmount { get; set; }

			[CandidName("create_error")]
			public string CreateError { get; set; }

			public RefundedInfo(UnboundedUInt refundAmount, string createError)
			{
				this.RefundAmount = refundAmount;
				this.CreateError = createError;
			}

			public RefundedInfo()
			{
			}
		}
	}

	public enum CreateCanisterErrorTag
	{
		Refunded
	}
}