using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System.Collections.Generic;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class GetNodeOperatorsAndDcsOfNodeProviderResponse
	{
		[VariantTagProperty]
		public GetNodeOperatorsAndDcsOfNodeProviderResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetNodeOperatorsAndDcsOfNodeProviderResponse(GetNodeOperatorsAndDcsOfNodeProviderResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetNodeOperatorsAndDcsOfNodeProviderResponse()
		{
		}

		public static GetNodeOperatorsAndDcsOfNodeProviderResponse Ok(Dictionary<DataCenterRecord, NodeOperatorRecord> info)
		{
			return new GetNodeOperatorsAndDcsOfNodeProviderResponse(GetNodeOperatorsAndDcsOfNodeProviderResponseTag.Ok, info);
		}

		public static GetNodeOperatorsAndDcsOfNodeProviderResponse Err(string info)
		{
			return new GetNodeOperatorsAndDcsOfNodeProviderResponse(GetNodeOperatorsAndDcsOfNodeProviderResponseTag.Err, info);
		}

		public Dictionary<DataCenterRecord, NodeOperatorRecord> AsOk()
		{
			this.ValidateTag(GetNodeOperatorsAndDcsOfNodeProviderResponseTag.Ok);
			return (Dictionary<DataCenterRecord, NodeOperatorRecord>)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(GetNodeOperatorsAndDcsOfNodeProviderResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(GetNodeOperatorsAndDcsOfNodeProviderResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetNodeOperatorsAndDcsOfNodeProviderResponseTag
	{
		Ok,
		Err
	}
}