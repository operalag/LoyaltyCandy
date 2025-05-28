using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class AddOrRemoveNodeProvider
	{
		[CandidName("change")]
		public OptionalValue<Change> Change { get; set; }

		public AddOrRemoveNodeProvider(OptionalValue<Change> change)
		{
			this.Change = change;
		}

		public AddOrRemoveNodeProvider()
		{
		}
	}
}