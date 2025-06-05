using EdjCase.ICP.Candid.Mapping;
using Score = System.UInt32;
using Rank = System.Int16;
using PlayerName = System.String;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class GameData
    {
        [CandidName("avatar")]
        public bool Avatar { get; set; }

        [CandidName("gem")]
        public ulong Gem { get; set; }

        public GameData(bool avatar, ulong gem)
        {
            this.Avatar = avatar;
            this.Gem = gem;
        }

        public GameData()
        {
        }
    }
	
}