using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class IPv4Config
	{
		[CandidName("prefix_length")]
		public uint PrefixLength { get; set; }

		[CandidName("gateway_ip_addr")]
		public string GatewayIpAddr { get; set; }

		[CandidName("ip_addr")]
		public string IpAddr { get; set; }

		public IPv4Config(uint prefixLength, string gatewayIpAddr, string ipAddr)
		{
			this.PrefixLength = prefixLength;
			this.GatewayIpAddr = gatewayIpAddr;
			this.IpAddr = ipAddr;
		}

		public IPv4Config()
		{
		}
	}
}