using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Percentage
	{
		[CandidName("basis_points")]
		public OptionalValue<ulong> BasisPoints { get; set; }

		public Percentage(OptionalValue<ulong> basisPoints)
		{
			this.BasisPoints = basisPoints;
		}

		public Percentage()
		{
		}
	}
}