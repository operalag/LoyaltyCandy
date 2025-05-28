using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Icrc21ConsentMessageMetadata
	{
		[CandidName("language")]
		public string Language { get; set; }

		[CandidName("utc_offset_minutes")]
		public OptionalValue<short> UtcOffsetMinutes { get; set; }

		public Icrc21ConsentMessageMetadata(string language, OptionalValue<short> utcOffsetMinutes)
		{
			this.Language = language;
			this.UtcOffsetMinutes = utcOffsetMinutes;
		}

		public Icrc21ConsentMessageMetadata()
		{
		}
	}
}