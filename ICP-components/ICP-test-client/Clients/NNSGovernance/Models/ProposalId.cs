using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ProposalId
	{
		[CandidName("id")]
		public ulong Id { get; set; }

		public ProposalId(ulong id)
		{
			this.Id = id;
		}

		public ProposalId()
		{
		}
	}
}