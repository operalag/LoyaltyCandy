using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateElectedHostosVersionsPayload
	{
		[CandidName("release_package_urls")]
		public List<string> ReleasePackageUrls { get; set; }

		[CandidName("hostos_version_to_elect")]
		public OptionalValue<string> HostosVersionToElect { get; set; }

		[CandidName("hostos_versions_to_unelect")]
		public List<string> HostosVersionsToUnelect { get; set; }

		[CandidName("release_package_sha256_hex")]
		public OptionalValue<string> ReleasePackageSha256Hex { get; set; }

		public UpdateElectedHostosVersionsPayload(List<string> releasePackageUrls, OptionalValue<string> hostosVersionToElect, List<string> hostosVersionsToUnelect, OptionalValue<string> releasePackageSha256Hex)
		{
			this.ReleasePackageUrls = releasePackageUrls;
			this.HostosVersionToElect = hostosVersionToElect;
			this.HostosVersionsToUnelect = hostosVersionsToUnelect;
			this.ReleasePackageSha256Hex = releasePackageSha256Hex;
		}

		public UpdateElectedHostosVersionsPayload()
		{
		}
	}
}