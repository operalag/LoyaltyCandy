using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class IcpXdrConversionRate
	{
		[CandidName("timestamp_seconds")]
		public ulong TimestampSeconds { get; set; }

		[CandidName("xdr_permyriad_per_icp")]
		public ulong XdrPermyriadPerIcp { get; set; }

		public IcpXdrConversionRate(ulong timestampSeconds, ulong xdrPermyriadPerIcp)
		{
			this.TimestampSeconds = timestampSeconds;
			this.XdrPermyriadPerIcp = xdrPermyriadPerIcp;
		}

		public IcpXdrConversionRate()
		{
		}
	}
}