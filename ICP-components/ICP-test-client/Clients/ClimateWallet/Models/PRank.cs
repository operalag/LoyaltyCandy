using EdjCase.ICP.Candid.Mapping;
using Score = System.UInt32;
using Rank = System.Int16;
using PlayerName = System.String;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class PRank
	{
		[CandidName("name")]
		public PlayerName Name { get; set; }

		[CandidName("rank")]
		public Rank Rank { get; set; }

		[CandidName("score")]
		public Score Score { get; set; }

		public PRank(PlayerName name, Rank rank, Score score)
		{
			this.Name = name;
			this.Rank = rank;
			this.Score = score;
		}

		public PRank()
		{
		}
	}
}