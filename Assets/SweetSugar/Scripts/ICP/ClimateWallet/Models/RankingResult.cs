using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.ClimateWallet.Models;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class RankingResult
	{
		[CandidName("ranking")]
		public List<PRank> Ranking { get; set; }

		public RankingResult(List<PRank> ranking)
		{
			this.Ranking = ranking;
		}

		public RankingResult()
		{
		}
	}
}