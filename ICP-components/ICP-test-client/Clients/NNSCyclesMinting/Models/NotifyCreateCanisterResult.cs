using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class NotifyCreateCanisterResult
	{
		[VariantTagProperty]
		public NotifyCreateCanisterResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public NotifyCreateCanisterResult(NotifyCreateCanisterResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected NotifyCreateCanisterResult()
		{
		}

		public static NotifyCreateCanisterResult Ok(Principal info)
		{
			return new NotifyCreateCanisterResult(NotifyCreateCanisterResultTag.Ok, info);
		}

		public static NotifyCreateCanisterResult Err(NotifyError info)
		{
			return new NotifyCreateCanisterResult(NotifyCreateCanisterResultTag.Err, info);
		}

		public Principal AsOk()
		{
			this.ValidateTag(NotifyCreateCanisterResultTag.Ok);
			return (Principal)this.Value!;
		}

		public NotifyError AsErr()
		{
			this.ValidateTag(NotifyCreateCanisterResultTag.Err);
			return (NotifyError)this.Value!;
		}

		private void ValidateTag(NotifyCreateCanisterResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum NotifyCreateCanisterResultTag
	{
		Ok,
		Err
	}
}