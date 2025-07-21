using EdjCase.ICP.Candid.Mapping;
using Score = System.UInt32;
using Rank = System.Int16;
using PlayerName = System.String;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class PRank
	{
		[CandidName("isMale")]
		public bool IsMale { get; set; }

		[CandidName("name")]
		public PlayerName Name { get; set; }

		[CandidName("playerAddress")]
		public string PlayerAddress { get; set; }

		[CandidName("rank")]
		public Rank Rank { get; set; }

		[CandidName("rewarded")]
		public bool Rewarded { get; set; }

		[CandidName("score")]
		public Score Score { get; set; }

		public PRank(bool isMale, PlayerName name, string playerAddress, Rank rank, bool rewarded, Score score)
		{
			this.IsMale = isMale;
			this.Name = name;
			this.PlayerAddress = playerAddress;
			this.Rank = rank;
			this.Rewarded = rewarded;
			this.Score = score;
		}

		public PRank()
		{
		}
	}
}