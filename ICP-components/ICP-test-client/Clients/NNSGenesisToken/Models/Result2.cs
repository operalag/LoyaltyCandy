using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGenesisToken.Models;
using System;

namespace LoyaltyCandy.NNSGenesisToken.Models
{
	[Variant]
	public class Result2
	{
		[VariantTagProperty]
		public Result2Tag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Result2(Result2Tag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Result2()
		{
		}

		public static Result2 Ok(AccountState info)
		{
			return new Result2(Result2Tag.Ok, info);
		}

		public static Result2 Err(string info)
		{
			return new Result2(Result2Tag.Err, info);
		}

		public AccountState AsOk()
		{
			this.ValidateTag(Result2Tag.Ok);
			return (AccountState)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(Result2Tag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(Result2Tag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum Result2Tag
	{
		Ok,
		Err
	}
}