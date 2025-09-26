using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class CreateCanisterResult
	{
		[VariantTagProperty]
		public CreateCanisterResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public CreateCanisterResult(CreateCanisterResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected CreateCanisterResult()
		{
		}

		public static CreateCanisterResult Ok(Principal info)
		{
			return new CreateCanisterResult(CreateCanisterResultTag.Ok, info);
		}

		public static CreateCanisterResult Err(CreateCanisterError info)
		{
			return new CreateCanisterResult(CreateCanisterResultTag.Err, info);
		}

		public Principal AsOk()
		{
			this.ValidateTag(CreateCanisterResultTag.Ok);
			return (Principal)this.Value!;
		}

		public CreateCanisterError AsErr()
		{
			this.ValidateTag(CreateCanisterResultTag.Err);
			return (CreateCanisterError)this.Value!;
		}

		private void ValidateTag(CreateCanisterResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum CreateCanisterResultTag
	{
		Ok,
		Err
	}
}