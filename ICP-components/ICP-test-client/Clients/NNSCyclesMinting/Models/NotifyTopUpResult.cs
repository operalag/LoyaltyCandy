using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using System;
using Cycles = EdjCase.ICP.Candid.Models.UnboundedUInt;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class NotifyTopUpResult
	{
		[VariantTagProperty]
		public NotifyTopUpResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public NotifyTopUpResult(NotifyTopUpResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected NotifyTopUpResult()
		{
		}

		public static NotifyTopUpResult Ok(Cycles info)
		{
			return new NotifyTopUpResult(NotifyTopUpResultTag.Ok, info);
		}

		public static NotifyTopUpResult Err(NotifyError info)
		{
			return new NotifyTopUpResult(NotifyTopUpResultTag.Err, info);
		}

		public Cycles AsOk()
		{
			this.ValidateTag(NotifyTopUpResultTag.Ok);
			return (Cycles)this.Value!;
		}

		public NotifyError AsErr()
		{
			this.ValidateTag(NotifyTopUpResultTag.Err);
			return (NotifyError)this.Value!;
		}

		private void ValidateTag(NotifyTopUpResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum NotifyTopUpResultTag
	{
		Ok,
		Err
	}
}