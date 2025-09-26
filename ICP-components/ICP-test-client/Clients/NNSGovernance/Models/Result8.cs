using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class Result8
	{
		[VariantTagProperty]
		public Result8Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result8(Result8Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result8()
		{
		}

		public static Result8 Committed(Committed info)
		{
			return new Result8(Result8Tag.Committed, info);
		}

		public static Result8 Aborted(Result8.AbortedInfo info)
		{
			return new Result8(Result8Tag.Aborted, info);
		}

		public Committed AsCommitted()
		{
			this.ValidateTag(Result8Tag.Committed);
			return (Committed)this.Value!;
		}

		public Result8.AbortedInfo AsAborted()
		{
			this.ValidateTag(Result8Tag.Aborted);
			return (Result8.AbortedInfo)this.Value!;
		}

		private void ValidateTag(Result8Tag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class AbortedInfo
		{
			public AbortedInfo()
			{
			}
		}
	}

	public enum Result8Tag
	{
		Committed,
		Aborted
	}
}