using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class RemoveHotKey
	{
		[CandidName("hot_key_to_remove")]
		public OptionalValue<Principal> HotKeyToRemove { get; set; }

		public RemoveHotKey(OptionalValue<Principal> hotKeyToRemove)
		{
			this.HotKeyToRemove = hotKeyToRemove;
		}

		public RemoveHotKey()
		{
		}
	}
}