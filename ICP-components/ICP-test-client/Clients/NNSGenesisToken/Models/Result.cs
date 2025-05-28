using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGenesisToken.Models;
using System.Collections.Generic;
using System;

namespace LoyaltyCandy.NNSGenesisToken.Models
{
	[Variant]
	public class Result
	{
		[VariantTagProperty]
		public ResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result(ResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result()
		{
		}

		public static Result Ok(List<NeuronId> info)
		{
			return new Result(ResultTag.Ok, info);
		}

		public static Result Err(string info)
		{
			return new Result(ResultTag.Err, info);
		}

		public List<NeuronId> AsOk()
		{
			this.ValidateTag(ResultTag.Ok);
			return (List<NeuronId>)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(ResultTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(ResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum ResultTag
	{
		Ok,
		Err
	}
}