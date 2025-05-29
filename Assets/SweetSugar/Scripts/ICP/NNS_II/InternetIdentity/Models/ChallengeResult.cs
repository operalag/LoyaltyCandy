using EdjCase.ICP.Candid.Mapping;
using ChallengeKey = System.String;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class ChallengeResult
	{
		[CandidName("key")]
		public ChallengeKey Key { get; set; }

		[CandidName("chars")]
		public string Chars { get; set; }

		public ChallengeResult(ChallengeKey key, string chars)
		{
			this.Key = key;
			this.Chars = chars;
		}

		public ChallengeResult()
		{
		}
	}
}