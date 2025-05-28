using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class RerouteCanisterRangesPayload
	{
		[CandidName("source_subnet")]
		public Principal SourceSubnet { get; set; }

		[CandidName("reassigned_canister_ranges")]
		public List<CanisterIdRange> ReassignedCanisterRanges { get; set; }

		[CandidName("destination_subnet")]
		public Principal DestinationSubnet { get; set; }

		public RerouteCanisterRangesPayload(Principal sourceSubnet, List<CanisterIdRange> reassignedCanisterRanges, Principal destinationSubnet)
		{
			this.SourceSubnet = sourceSubnet;
			this.ReassignedCanisterRanges = reassignedCanisterRanges;
			this.DestinationSubnet = destinationSubnet;
		}

		public RerouteCanisterRangesPayload()
		{
		}
	}
}