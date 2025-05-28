using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class Chunk
	{
		[CandidName("content")]
		public OptionalValue<List<byte>> Content { get; set; }

		public Chunk(OptionalValue<List<byte>> content)
		{
			this.Content = content;
		}

		public Chunk()
		{
		}
	}
}