using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Icrc21ConsentMessageRequest
	{
		[CandidName("method")]
		public string Method { get; set; }

		[CandidName("arg")]
		public List<byte> Arg { get; set; }

		[CandidName("user_preferences")]
		public Icrc21ConsentMessageSpec UserPreferences { get; set; }

		public Icrc21ConsentMessageRequest(string method, List<byte> arg, Icrc21ConsentMessageSpec userPreferences)
		{
			this.Method = method;
			this.Arg = arg;
			this.UserPreferences = userPreferences;
		}

		public Icrc21ConsentMessageRequest()
		{
		}
	}
}