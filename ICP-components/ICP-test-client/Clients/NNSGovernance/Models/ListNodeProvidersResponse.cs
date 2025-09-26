using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListNodeProvidersResponse
	{
		[CandidName("node_providers")]
		public List<NodeProvider> NodeProviders { get; set; }

		public ListNodeProvidersResponse(List<NodeProvider> nodeProviders)
		{
			this.NodeProviders = nodeProviders;
		}

		public ListNodeProvidersResponse()
		{
		}
	}
}