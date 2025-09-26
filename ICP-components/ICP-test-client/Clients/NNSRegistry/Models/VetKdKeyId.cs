using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class VetKdKeyId
	{
		[CandidName("curve")]
		public VetKdCurve Curve { get; set; }

		[CandidName("name")]
		public string Name { get; set; }

		public VetKdKeyId(VetKdCurve curve, string name)
		{
			this.Curve = curve;
			this.Name = name;
		}

		public VetKdKeyId()
		{
		}
	}
}