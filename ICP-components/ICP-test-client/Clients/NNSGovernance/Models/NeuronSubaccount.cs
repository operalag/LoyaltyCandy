using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronSubaccount
	{
		[CandidName("subaccount")]
		public List<byte> Subaccount { get; set; }

		public NeuronSubaccount(List<byte> subaccount)
		{
			this.Subaccount = subaccount;
		}

		public NeuronSubaccount()
		{
		}
	}
}