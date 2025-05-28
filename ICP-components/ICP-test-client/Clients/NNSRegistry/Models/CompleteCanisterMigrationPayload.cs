using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class CompleteCanisterMigrationPayload
	{
		[CandidName("canister_id_ranges")]
		public List<CanisterIdRange> CanisterIdRanges { get; set; }

		[CandidName("migration_trace")]
		public List<Principal> MigrationTrace { get; set; }

		public CompleteCanisterMigrationPayload(List<CanisterIdRange> canisterIdRanges, List<Principal> migrationTrace)
		{
			this.CanisterIdRanges = canisterIdRanges;
			this.MigrationTrace = migrationTrace;
		}

		public CompleteCanisterMigrationPayload()
		{
		}
	}
}