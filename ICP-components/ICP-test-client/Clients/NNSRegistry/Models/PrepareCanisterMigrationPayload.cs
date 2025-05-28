using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class PrepareCanisterMigrationPayload
	{
		[CandidName("canister_id_ranges")]
		public List<CanisterIdRange> CanisterIdRanges { get; set; }

		[CandidName("source_subnet")]
		public Principal SourceSubnet { get; set; }

		[CandidName("destination_subnet")]
		public Principal DestinationSubnet { get; set; }

		public PrepareCanisterMigrationPayload(List<CanisterIdRange> canisterIdRanges, Principal sourceSubnet, Principal destinationSubnet)
		{
			this.CanisterIdRanges = canisterIdRanges;
			this.SourceSubnet = sourceSubnet;
			this.DestinationSubnet = destinationSubnet;
		}

		public PrepareCanisterMigrationPayload()
		{
		}
	}
}