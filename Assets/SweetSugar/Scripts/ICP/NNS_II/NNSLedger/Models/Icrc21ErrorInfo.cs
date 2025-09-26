using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Icrc21ErrorInfo
	{
		[CandidName("description")]
		public string Description { get; set; }

		public Icrc21ErrorInfo(string description)
		{
			this.Description = description;
		}

		public Icrc21ErrorInfo()
		{
		}
	}
}