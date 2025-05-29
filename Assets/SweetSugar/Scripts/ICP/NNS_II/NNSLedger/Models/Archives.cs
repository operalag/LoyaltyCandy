using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Archives
	{
		[CandidName("archives")]
		public List<Archive> Archives_ { get; set; }

		public Archives(List<Archive> archives)
		{
			this.Archives_ = archives;
		}

		public Archives()
		{
		}
	}
}