using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class Result6
	{
		[VariantTagProperty]
		public Result6Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result6(Result6Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result6()
		{
		}

		public static Result6 Ok(Ok info)
		{
			return new Result6(Result6Tag.Ok, info);
		}

		public static Result6 Err(GovernanceError info)
		{
			return new Result6(Result6Tag.Err, info);
		}

		public Ok AsOk()
		{
			this.ValidateTag(Result6Tag.Ok);
			return (Ok)this.Value!;
		}

		public GovernanceError AsErr()
		{
			this.ValidateTag(Result6Tag.Err);
			return (GovernanceError)this.Value!;
		}

		private void ValidateTag(Result6Tag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum Result6Tag
	{
		Ok,
		Err
	}
}