using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public enum KeyType
	{
		[CandidName("unknown")]
		Unknown,
		[CandidName("platform")]
		Platform,
		[CandidName("cross_platform")]
		CrossPlatform,
		[CandidName("seed_phrase")]
		SeedPhrase,
		[CandidName("browser_storage_key")]
		BrowserStorageKey
	}
}