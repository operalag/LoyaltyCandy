using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class ExchangeRateCanister
	{
		[VariantTagProperty]
		public ExchangeRateCanisterTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public ExchangeRateCanister(ExchangeRateCanisterTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected ExchangeRateCanister()
		{
		}

		public static ExchangeRateCanister Set(Principal info)
		{
			return new ExchangeRateCanister(ExchangeRateCanisterTag.Set, info);
		}

		public static ExchangeRateCanister Unset()
		{
			return new ExchangeRateCanister(ExchangeRateCanisterTag.Unset, null);
		}

		public Principal AsSet()
		{
			this.ValidateTag(ExchangeRateCanisterTag.Set);
			return (Principal)this.Value!;
		}

		private void ValidateTag(ExchangeRateCanisterTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum ExchangeRateCanisterTag
	{
		Set,
		Unset
	}
}