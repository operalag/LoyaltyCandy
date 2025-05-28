using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ApproveGenesisKyc
	{
		[CandidName("principals")]
		public List<Principal> Principals { get; set; }

		public ApproveGenesisKyc(List<Principal> principals)
		{
			this.Principals = principals;
		}

		public ApproveGenesisKyc()
		{
		}
	}
}