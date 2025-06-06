using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class GameData
	{
		[CandidName("gem")]
		public double Gem { get; set; }

		[CandidName("isMale")]
		public bool IsMale { get; set; }

		public GameData(double gem, bool isMale)
		{
			this.Gem = gem;
			this.IsMale = isMale;
		}

		public GameData()
		{
		}
	}
}