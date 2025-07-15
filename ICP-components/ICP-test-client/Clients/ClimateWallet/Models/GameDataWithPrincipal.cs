using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.ClimateWallet.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.ClimateWallet.Models
{
	public class GameDataWithPrincipal
	{
		[CandidName("data")]
		public GameDataShared Data { get; set; }

		[CandidName("principal")]
		public Principal Principal { get; set; }

		public GameDataWithPrincipal(GameDataShared data, Principal principal)
		{
			this.Data = data;
			this.Principal = principal;
		}

		public GameDataWithPrincipal()
		{
		}
	}
}