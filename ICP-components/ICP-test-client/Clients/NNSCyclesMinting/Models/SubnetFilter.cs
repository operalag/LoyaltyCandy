using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class SubnetFilter
	{
		[CandidName("subnet_type")]
		public OptionalValue<string> SubnetType { get; set; }

		public SubnetFilter(OptionalValue<string> subnetType)
		{
			this.SubnetType = subnetType;
		}

		public SubnetFilter()
		{
		}
	}
}