using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System.Collections.Generic;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class GetApiBoundaryNodeIdsResponse
	{
		[VariantTagProperty]
		public GetApiBoundaryNodeIdsResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetApiBoundaryNodeIdsResponse(GetApiBoundaryNodeIdsResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetApiBoundaryNodeIdsResponse()
		{
		}

		public static GetApiBoundaryNodeIdsResponse Ok(List<ApiBoundaryNodeIdRecord> info)
		{
			return new GetApiBoundaryNodeIdsResponse(GetApiBoundaryNodeIdsResponseTag.Ok, info);
		}

		public static GetApiBoundaryNodeIdsResponse Err(string info)
		{
			return new GetApiBoundaryNodeIdsResponse(GetApiBoundaryNodeIdsResponseTag.Err, info);
		}

		public List<ApiBoundaryNodeIdRecord> AsOk()
		{
			this.ValidateTag(GetApiBoundaryNodeIdsResponseTag.Ok);
			return (List<ApiBoundaryNodeIdRecord>)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(GetApiBoundaryNodeIdsResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(GetApiBoundaryNodeIdsResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetApiBoundaryNodeIdsResponseTag
	{
		Ok,
		Err
	}
}