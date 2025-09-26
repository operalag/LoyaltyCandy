using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRoot.Models;
using System;

namespace LoyaltyCandy.NNSRoot.Models
{
	[Variant]
	public class ChangeCanisterControllersResult
	{
		[VariantTagProperty]
		public ChangeCanisterControllersResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public ChangeCanisterControllersResult(ChangeCanisterControllersResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected ChangeCanisterControllersResult()
		{
		}

		public static ChangeCanisterControllersResult Ok()
		{
			return new ChangeCanisterControllersResult(ChangeCanisterControllersResultTag.Ok, null);
		}

		public static ChangeCanisterControllersResult Err(ChangeCanisterControllersError info)
		{
			return new ChangeCanisterControllersResult(ChangeCanisterControllersResultTag.Err, info);
		}

		public ChangeCanisterControllersError AsErr()
		{
			this.ValidateTag(ChangeCanisterControllersResultTag.Err);
			return (ChangeCanisterControllersError)this.Value!;
		}

		private void ValidateTag(ChangeCanisterControllersResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum ChangeCanisterControllersResultTag
	{
		Ok,
		Err
	}
}