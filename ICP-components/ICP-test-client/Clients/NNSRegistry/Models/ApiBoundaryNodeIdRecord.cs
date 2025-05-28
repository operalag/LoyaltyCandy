using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class ApiBoundaryNodeIdRecord
	{
		[CandidName("id")]
		public OptionalValue<Principal> Id { get; set; }

		public ApiBoundaryNodeIdRecord(OptionalValue<Principal> id)
		{
			this.Id = id;
		}

		public ApiBoundaryNodeIdRecord()
		{
		}
	}
}