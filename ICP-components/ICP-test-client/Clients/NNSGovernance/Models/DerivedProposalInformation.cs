using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class DerivedProposalInformation
	{
		[CandidName("swap_background_information")]
		public OptionalValue<SwapBackgroundInformation> SwapBackgroundInformation { get; set; }

		public DerivedProposalInformation(OptionalValue<SwapBackgroundInformation> swapBackgroundInformation)
		{
			this.SwapBackgroundInformation = swapBackgroundInformation;
		}

		public DerivedProposalInformation()
		{
		}
	}
}