using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class Result9
	{
		[VariantTagProperty]
		public Result9Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result9(Result9Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result9()
		{
		}

		public static Result9 Committed(Committed1 info)
		{
			return new Result9(Result9Tag.Committed, info);
		}

		public static Result9 Aborted(Result9.AbortedInfo info)
		{
			return new Result9(Result9Tag.Aborted, info);
		}

		public Committed1 AsCommitted()
		{
			this.ValidateTag(Result9Tag.Committed);
			return (Committed1)this.Value!;
		}

		public Result9.AbortedInfo AsAborted()
		{
			this.ValidateTag(Result9Tag.Aborted);
			return (Result9.AbortedInfo)this.Value!;
		}

		private void ValidateTag(Result9Tag tag)
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

	public enum Result9Tag
	{
		Committed,
		Aborted
	}
}