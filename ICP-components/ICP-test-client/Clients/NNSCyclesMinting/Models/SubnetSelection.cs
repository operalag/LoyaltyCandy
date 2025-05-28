using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using System;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	[Variant]
	public class SubnetSelection
	{
		[VariantTagProperty]
		public SubnetSelectionTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public SubnetSelection(SubnetSelectionTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected SubnetSelection()
		{
		}

		public static SubnetSelection Subnet(SubnetSelection.SubnetInfo info)
		{
			return new SubnetSelection(SubnetSelectionTag.Subnet, info);
		}

		public static SubnetSelection Filter(SubnetFilter info)
		{
			return new SubnetSelection(SubnetSelectionTag.Filter, info);
		}

		public SubnetSelection.SubnetInfo AsSubnet()
		{
			this.ValidateTag(SubnetSelectionTag.Subnet);
			return (SubnetSelection.SubnetInfo)this.Value!;
		}

		public SubnetFilter AsFilter()
		{
			this.ValidateTag(SubnetSelectionTag.Filter);
			return (SubnetFilter)this.Value!;
		}

		private void ValidateTag(SubnetSelectionTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class SubnetInfo
		{
			[CandidName("subnet")]
			public Principal Subnet { get; set; }

			public SubnetInfo(Principal subnet)
			{
				this.Subnet = subnet;
			}

			public SubnetInfo()
			{
			}
		}
	}

	public enum SubnetSelectionTag
	{
		Subnet,
		Filter
	}
}