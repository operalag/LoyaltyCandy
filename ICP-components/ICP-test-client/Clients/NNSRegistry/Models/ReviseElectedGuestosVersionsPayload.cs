using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class ReviseElectedGuestosVersionsPayload
	{
		[CandidName("release_package_urls")]
		public List<string> ReleasePackageUrls { get; set; }

		[CandidName("replica_versions_to_unelect")]
		public List<string> ReplicaVersionsToUnelect { get; set; }

		[CandidName("replica_version_to_elect")]
		public OptionalValue<string> ReplicaVersionToElect { get; set; }

		[CandidName("guest_launch_measurement_sha256_hex")]
		public OptionalValue<string> GuestLaunchMeasurementSha256Hex { get; set; }

		[CandidName("release_package_sha256_hex")]
		public OptionalValue<string> ReleasePackageSha256Hex { get; set; }

		public ReviseElectedGuestosVersionsPayload(List<string> releasePackageUrls, List<string> replicaVersionsToUnelect, OptionalValue<string> replicaVersionToElect, OptionalValue<string> guestLaunchMeasurementSha256Hex, OptionalValue<string> releasePackageSha256Hex)
		{
			this.ReleasePackageUrls = releasePackageUrls;
			this.ReplicaVersionsToUnelect = replicaVersionsToUnelect;
			this.ReplicaVersionToElect = replicaVersionToElect;
			this.GuestLaunchMeasurementSha256Hex = guestLaunchMeasurementSha256Hex;
			this.ReleasePackageSha256Hex = releasePackageSha256Hex;
		}

		public ReviseElectedGuestosVersionsPayload()
		{
		}
	}
}