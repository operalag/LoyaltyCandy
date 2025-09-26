using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Decimal
	{
		[CandidName("human_readable")]
		public OptionalValue<string> HumanReadable { get; set; }

		public Decimal(OptionalValue<string> humanReadable)
		{
			this.HumanReadable = humanReadable;
		}

		public Decimal()
		{
		}
	}
}