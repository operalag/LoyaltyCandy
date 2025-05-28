using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSDapp.Models;
using System;

namespace LoyaltyCandy.NNSDapp.Models
{
	[Variant]
	public class GetProposalPayloadResponse
	{
		[VariantTagProperty]
		public GetProposalPayloadResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetProposalPayloadResponse(GetProposalPayloadResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetProposalPayloadResponse()
		{
		}

		public static GetProposalPayloadResponse Ok(string info)
		{
			return new GetProposalPayloadResponse(GetProposalPayloadResponseTag.Ok, info);
		}

		public static GetProposalPayloadResponse Err(string info)
		{
			return new GetProposalPayloadResponse(GetProposalPayloadResponseTag.Err, info);
		}

		public string AsOk()
		{
			this.ValidateTag(GetProposalPayloadResponseTag.Ok);
			return (string)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(GetProposalPayloadResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(GetProposalPayloadResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetProposalPayloadResponseTag
	{
		Ok,
		Err
	}
}