using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSCyclesMinting.Models;
using BlockIndex = System.UInt64;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class NotifyCreateCanisterArg
	{
		[CandidName("block_index")]
		public BlockIndex BlockIndex { get; set; }

		[CandidName("controller")]
		public Principal Controller { get; set; }

		[CandidName("subnet_type")]
		public OptionalValue<string> SubnetType { get; set; }

		[CandidName("subnet_selection")]
		public OptionalValue<SubnetSelection> SubnetSelection { get; set; }

		[CandidName("settings")]
		public OptionalValue<CanisterSettings> Settings { get; set; }

		public NotifyCreateCanisterArg(BlockIndex blockIndex, Principal controller, OptionalValue<string> subnetType, OptionalValue<SubnetSelection> subnetSelection, OptionalValue<CanisterSettings> settings)
		{
			this.BlockIndex = blockIndex;
			this.Controller = controller;
			this.SubnetType = subnetType;
			this.SubnetSelection = subnetSelection;
			this.Settings = settings;
		}

		public NotifyCreateCanisterArg()
		{
		}
	}
}