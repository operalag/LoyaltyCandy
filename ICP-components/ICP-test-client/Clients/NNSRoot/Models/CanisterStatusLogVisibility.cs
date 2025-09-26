using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRoot.Models;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.NNSRoot.Models
{
	[Variant]
	public class CanisterStatusLogVisibility
	{
		[VariantTagProperty]
		public CanisterStatusLogVisibilityTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public CanisterStatusLogVisibility(CanisterStatusLogVisibilityTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected CanisterStatusLogVisibility()
		{
		}

		public static CanisterStatusLogVisibility Controllers()
		{
			return new CanisterStatusLogVisibility(CanisterStatusLogVisibilityTag.Controllers, null);
		}

		public static CanisterStatusLogVisibility Public()
		{
			return new CanisterStatusLogVisibility(CanisterStatusLogVisibilityTag.Public, null);
		}

		public static CanisterStatusLogVisibility AllowedViewers(List<Principal> info)
		{
			return new CanisterStatusLogVisibility(CanisterStatusLogVisibilityTag.AllowedViewers, info);
		}

		public List<Principal> AsAllowedViewers()
		{
			this.ValidateTag(CanisterStatusLogVisibilityTag.AllowedViewers);
			return (List<Principal>)this.Value!;
		}

		private void ValidateTag(CanisterStatusLogVisibilityTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum CanisterStatusLogVisibilityTag
	{
		[CandidName("controllers")]
		Controllers,
		[CandidName("public")]
		Public,
		[CandidName("allowed_viewers")]
		AllowedViewers
	}
}