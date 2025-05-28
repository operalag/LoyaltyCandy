using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class SetVisibility
	{
		[CandidName("visibility")]
		public OptionalValue<int> Visibility { get; set; }

		public SetVisibility(OptionalValue<int> visibility)
		{
			this.Visibility = visibility;
		}

		public SetVisibility()
		{
		}
	}
}