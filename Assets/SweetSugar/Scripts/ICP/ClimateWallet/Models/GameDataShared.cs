using EdjCase.ICP.Candid.Mapping;
using Score = System.UInt32;
using Rank = System.Int16;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class GameDataShared
	{
		[CandidName("isMale")]
		public bool IsMale { get; set; }

		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("playerAddress")]
		public string PlayerAddress { get; set; }

		[CandidName("rank")]
		public short Rank { get; set; }

		[CandidName("rewarded")]
		public bool Rewarded { get; set; }

		[CandidName("score")]
		public uint Score { get; set; }

		[CandidName("weeklyRank")]
		public short WeeklyRank { get; set; }

		public GameDataShared(bool isMale, string name, string playerAddress, short rank, bool rewarded, uint score, short weeklyRank)
		{
			this.IsMale = isMale;
			this.Name = name;
			this.PlayerAddress = playerAddress;
			this.Rank = rank;
			this.Rewarded = rewarded;
			this.Score = score;
			this.WeeklyRank = weeklyRank;
		}

		public GameDataShared()
		{
		}
	}
}