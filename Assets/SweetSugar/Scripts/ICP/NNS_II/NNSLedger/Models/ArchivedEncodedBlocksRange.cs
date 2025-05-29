using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models.Values;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class ArchivedEncodedBlocksRange
	{
		[CandidName("callback")]
		[CandidTypeDefinition("( GetBlocksArgs ) -> ( variant { Ok:vec vec nat8; Err:QueryArchiveError } ) query")]
		public CandidFunc Callback { get; set; }

		[CandidName("start")]
		public ulong Start { get; set; }

		[CandidName("length")]
		public ulong Length { get; set; }

		public ArchivedEncodedBlocksRange(CandidFunc callback, ulong start, ulong length)
		{
			this.Callback = callback;
			this.Start = start;
			this.Length = length;
		}

		public ArchivedEncodedBlocksRange()
		{
		}
	}
}