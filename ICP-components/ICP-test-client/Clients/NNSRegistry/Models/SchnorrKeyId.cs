using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class SchnorrKeyId
	{
		[CandidName("algorithm")]
		public SchnorrAlgorithm Algorithm { get; set; }

		[CandidName("name")]
		public string Name { get; set; }

		public SchnorrKeyId(SchnorrAlgorithm algorithm, string name)
		{
			this.Algorithm = algorithm;
			this.Name = name;
		}

		public SchnorrKeyId()
		{
		}
	}
}