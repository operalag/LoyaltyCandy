using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class RateLimitConfig
	{
		[CandidName("time_per_token_ns")]
		public ulong TimePerTokenNs { get; set; }

		[CandidName("max_tokens")]
		public ulong MaxTokens { get; set; }

		public RateLimitConfig(ulong timePerTokenNs, ulong maxTokens)
		{
			this.TimePerTokenNs = timePerTokenNs;
			this.MaxTokens = maxTokens;
		}

		public RateLimitConfig()
		{
		}
	}
}