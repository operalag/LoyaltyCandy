using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class ICPTs
	{
		[CandidName("e8s")]
		public ulong E8s { get; set; }

		public ICPTs(ulong e8s)
		{
			this.E8s = e8s;
		}

		public ICPTs()
		{
		}
	}
}