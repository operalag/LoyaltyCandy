using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Icrc21ConsentInfo
	{
		[CandidName("consent_message")]
		public Icrc21ConsentMessage ConsentMessage { get; set; }

		[CandidName("metadata")]
		public Icrc21ConsentMessageMetadata Metadata { get; set; }

		public Icrc21ConsentInfo(Icrc21ConsentMessage consentMessage, Icrc21ConsentMessageMetadata metadata)
		{
			this.ConsentMessage = consentMessage;
			this.Metadata = metadata;
		}

		public Icrc21ConsentInfo()
		{
		}
	}
}