using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateNodeIPv4ConfigDirectlyPayload
	{
		[CandidName("ipv4_config")]
		public OptionalValue<IPv4Config> Ipv4Config { get; set; }

		[CandidName("node_id")]
		public Principal NodeId { get; set; }

		public UpdateNodeIPv4ConfigDirectlyPayload(OptionalValue<IPv4Config> ipv4Config, Principal nodeId)
		{
			this.Ipv4Config = ipv4Config;
			this.NodeId = nodeId;
		}

		public UpdateNodeIPv4ConfigDirectlyPayload()
		{
		}
	}
}