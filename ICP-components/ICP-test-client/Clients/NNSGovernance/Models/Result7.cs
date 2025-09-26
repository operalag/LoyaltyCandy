using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class Result7
	{
		[VariantTagProperty]
		public Result7Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result7(Result7Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result7()
		{
		}

		public static Result7 Ok(NodeProvider info)
		{
			return new Result7(Result7Tag.Ok, info);
		}

		public static Result7 Err(GovernanceError info)
		{
			return new Result7(Result7Tag.Err, info);
		}

		public NodeProvider AsOk()
		{
			this.ValidateTag(Result7Tag.Ok);
			return (NodeProvider)this.Value!;
		}

		public GovernanceError AsErr()
		{
			this.ValidateTag(Result7Tag.Err);
			return (GovernanceError)this.Value!;
		}

		private void ValidateTag(Result7Tag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum Result7Tag
	{
		Ok,
		Err
	}
}