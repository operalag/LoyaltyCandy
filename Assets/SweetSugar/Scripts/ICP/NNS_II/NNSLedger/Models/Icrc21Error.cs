using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using System;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class Icrc21Error
	{
		[VariantTagProperty]
		public Icrc21ErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Icrc21Error(Icrc21ErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Icrc21Error()
		{
		}

		public static Icrc21Error UnsupportedCanisterCall(Icrc21ErrorInfo info)
		{
			return new Icrc21Error(Icrc21ErrorTag.UnsupportedCanisterCall, info);
		}

		public static Icrc21Error ConsentMessageUnavailable(Icrc21ErrorInfo info)
		{
			return new Icrc21Error(Icrc21ErrorTag.ConsentMessageUnavailable, info);
		}

		public static Icrc21Error InsufficientPayment(Icrc21ErrorInfo info)
		{
			return new Icrc21Error(Icrc21ErrorTag.InsufficientPayment, info);
		}

		public static Icrc21Error GenericError(Icrc21Error.GenericErrorInfo info)
		{
			return new Icrc21Error(Icrc21ErrorTag.GenericError, info);
		}

		public Icrc21ErrorInfo AsUnsupportedCanisterCall()
		{
			this.ValidateTag(Icrc21ErrorTag.UnsupportedCanisterCall);
			return (Icrc21ErrorInfo)this.Value!;
		}

		public Icrc21ErrorInfo AsConsentMessageUnavailable()
		{
			this.ValidateTag(Icrc21ErrorTag.ConsentMessageUnavailable);
			return (Icrc21ErrorInfo)this.Value!;
		}

		public Icrc21ErrorInfo AsInsufficientPayment()
		{
			this.ValidateTag(Icrc21ErrorTag.InsufficientPayment);
			return (Icrc21ErrorInfo)this.Value!;
		}

		public Icrc21Error.GenericErrorInfo AsGenericError()
		{
			this.ValidateTag(Icrc21ErrorTag.GenericError);
			return (Icrc21Error.GenericErrorInfo)this.Value!;
		}

		private void ValidateTag(Icrc21ErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class GenericErrorInfo
		{
			[CandidName("error_code")]
			public UnboundedUInt ErrorCode { get; set; }

			[CandidName("description")]
			public string Description { get; set; }

			public GenericErrorInfo(UnboundedUInt errorCode, string description)
			{
				this.ErrorCode = errorCode;
				this.Description = description;
			}

			public GenericErrorInfo()
			{
			}
		}
	}

	public enum Icrc21ErrorTag
	{
		UnsupportedCanisterCall,
		ConsentMessageUnavailable,
		InsufficientPayment,
		GenericError
	}
}