using EdjCase.ICP.Candid.Mapping;
using ChallengeKey = System.String;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class Challenge
	{
		[CandidName("png_base64")]
		public string PngBase64 { get; set; }

		[CandidName("challenge_key")]
		public ChallengeKey ChallengeKey { get; set; }

		public Challenge(string pngBase64, ChallengeKey challengeKey)
		{
			this.PngBase64 = pngBase64;
			this.ChallengeKey = challengeKey;
		}

		public Challenge()
		{
		}
	}
}