using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class EcdsaKeyId
	{
		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("curve")]
		public EcdsaCurve Curve { get; set; }

		public EcdsaKeyId(string name, EcdsaCurve curve)
		{
			this.Name = name;
			this.Curve = curve;
		}

		public EcdsaKeyId()
		{
		}
	}
}