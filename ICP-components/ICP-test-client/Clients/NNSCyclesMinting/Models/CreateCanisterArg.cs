using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSCyclesMinting.Models;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class CreateCanisterArg
	{
		[CandidName("settings")]
		public OptionalValue<CanisterSettings> Settings { get; set; }

		[CandidName("subnet_type")]
		public OptionalValue<string> SubnetType { get; set; }

		[CandidName("subnet_selection")]
		public OptionalValue<SubnetSelection> SubnetSelection { get; set; }

		public CreateCanisterArg(OptionalValue<CanisterSettings> settings, OptionalValue<string> subnetType, OptionalValue<SubnetSelection> subnetSelection)
		{
			this.Settings = settings;
			this.SubnetType = subnetType;
			this.SubnetSelection = subnetSelection;
		}

		public CreateCanisterArg()
		{
		}
	}
}