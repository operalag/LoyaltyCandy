using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using BlockIndex = System.UInt64;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class NotifyTopUpArg
	{
		[CandidName("block_index")]
		public BlockIndex BlockIndex { get; set; }

		[CandidName("canister_id")]
		public Principal CanisterId { get; set; }

		public NotifyTopUpArg(BlockIndex blockIndex, Principal canisterId)
		{
			this.BlockIndex = blockIndex;
			this.CanisterId = canisterId;
		}

		public NotifyTopUpArg()
		{
		}
	}
}