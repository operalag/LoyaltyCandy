using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class BlockRange
	{
		[CandidName("blocks")]
		public List<Block> Blocks { get; set; }

		public BlockRange(List<Block> blocks)
		{
			this.Blocks = blocks;
		}

		public BlockRange()
		{
		}
	}
}