using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using BlockIndex = System.UInt64;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class NotifyMintCyclesSuccess
	{
		[CandidName("block_index")]
		public UnboundedUInt BlockIndex { get; set; }

		[CandidName("minted")]
		public UnboundedUInt Minted { get; set; }

		[CandidName("balance")]
		public UnboundedUInt Balance { get; set; }

		public NotifyMintCyclesSuccess(UnboundedUInt blockIndex, UnboundedUInt minted, UnboundedUInt balance)
		{
			this.BlockIndex = blockIndex;
			this.Minted = minted;
			this.Balance = balance;
		}

		public NotifyMintCyclesSuccess()
		{
		}
	}
}