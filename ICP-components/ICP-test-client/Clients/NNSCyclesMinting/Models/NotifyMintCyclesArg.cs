using EdjCase.ICP.Candid.Mapping;
using BlockIndex = System.UInt64;
using Subaccount = EdjCase.ICP.Candid.Models.OptionalValue<System.Collections.Generic.List<System.Byte>>;
using Memo = EdjCase.ICP.Candid.Models.OptionalValue<System.Collections.Generic.List<System.Byte>>;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class NotifyMintCyclesArg
	{
		[CandidName("block_index")]
		public BlockIndex BlockIndex { get; set; }

		[CandidName("to_subaccount")]
		public Subaccount ToSubaccount { get; set; }

		[CandidName("deposit_memo")]
		public Memo DepositMemo { get; set; }

		public NotifyMintCyclesArg(BlockIndex blockIndex, Subaccount toSubaccount, Memo depositMemo)
		{
			this.BlockIndex = blockIndex;
			this.ToSubaccount = toSubaccount;
			this.DepositMemo = depositMemo;
		}

		public NotifyMintCyclesArg()
		{
		}
	}
}