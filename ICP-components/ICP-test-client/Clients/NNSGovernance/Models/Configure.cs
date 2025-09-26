using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Configure
	{
		[CandidName("operation")]
		public OptionalValue<Operation> Operation { get; set; }

		public Configure(OptionalValue<Operation> operation)
		{
			this.Operation = operation;
		}

		public Configure()
		{
		}
	}
}