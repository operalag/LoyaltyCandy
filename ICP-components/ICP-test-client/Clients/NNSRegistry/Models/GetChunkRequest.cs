using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class GetChunkRequest
	{
		[CandidName("content_sha256")]
		public OptionalValue<List<byte>> ContentSha256 { get; set; }

		public GetChunkRequest(OptionalValue<List<byte>> contentSha256)
		{
			this.ContentSha256 = contentSha256;
		}

		public GetChunkRequest()
		{
		}
	}
}