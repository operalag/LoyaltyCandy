using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class GetChunkResponse
	{
		[VariantTagProperty]
		public GetChunkResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetChunkResponse(GetChunkResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetChunkResponse()
		{
		}

		public static GetChunkResponse Ok(Chunk info)
		{
			return new GetChunkResponse(GetChunkResponseTag.Ok, info);
		}

		public static GetChunkResponse Err(string info)
		{
			return new GetChunkResponse(GetChunkResponseTag.Err, info);
		}

		public Chunk AsOk()
		{
			this.ValidateTag(GetChunkResponseTag.Ok);
			return (Chunk)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(GetChunkResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(GetChunkResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetChunkResponseTag
	{
		Ok,
		Err
	}
}