using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class Result10
	{
		[VariantTagProperty]
		public Result10Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result10(Result10Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result10()
		{
		}

		public static Result10 Ok(Ok1 info)
		{
			return new Result10(Result10Tag.Ok, info);
		}

		public static Result10 Err(GovernanceError info)
		{
			return new Result10(Result10Tag.Err, info);
		}

		public Ok1 AsOk()
		{
			this.ValidateTag(Result10Tag.Ok);
			return (Ok1)this.Value!;
		}

		public GovernanceError AsErr()
		{
			this.ValidateTag(Result10Tag.Err);
			return (GovernanceError)this.Value!;
		}

		private void ValidateTag(Result10Tag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum Result10Tag
	{
		Ok,
		Err
	}
}