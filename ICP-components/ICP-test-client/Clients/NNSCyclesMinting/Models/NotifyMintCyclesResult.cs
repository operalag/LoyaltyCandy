using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using System;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class NotifyMintCyclesResult
	{
		[VariantTagProperty]
		public NotifyMintCyclesResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public NotifyMintCyclesResult(NotifyMintCyclesResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected NotifyMintCyclesResult()
		{
		}

		public static NotifyMintCyclesResult Ok(NotifyMintCyclesSuccess info)
		{
			return new NotifyMintCyclesResult(NotifyMintCyclesResultTag.Ok, info);
		}

		public static NotifyMintCyclesResult Err(NotifyError info)
		{
			return new NotifyMintCyclesResult(NotifyMintCyclesResultTag.Err, info);
		}

		public NotifyMintCyclesSuccess AsOk()
		{
			this.ValidateTag(NotifyMintCyclesResultTag.Ok);
			return (NotifyMintCyclesSuccess)this.Value!;
		}

		public NotifyError AsErr()
		{
			this.ValidateTag(NotifyMintCyclesResultTag.Err);
			return (NotifyError)this.Value!;
		}

		private void ValidateTag(NotifyMintCyclesResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum NotifyMintCyclesResultTag
	{
		Ok,
		Err
	}
}