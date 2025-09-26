using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSGenesisToken.Models
{
	public class NeuronId
	{
		[CandidName("id")]
		public ulong Id { get; set; }

		public NeuronId(ulong id)
		{
			this.Id = id;
		}

		public NeuronId()
		{
		}
	}
}