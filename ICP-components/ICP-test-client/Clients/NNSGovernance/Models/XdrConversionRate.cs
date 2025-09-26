using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class XdrConversionRate
	{
		[CandidName("xdr_permyriad_per_icp")]
		public OptionalValue<ulong> XdrPermyriadPerIcp { get; set; }

		[CandidName("timestamp_seconds")]
		public OptionalValue<ulong> TimestampSeconds { get; set; }

		public XdrConversionRate(OptionalValue<ulong> xdrPermyriadPerIcp, OptionalValue<ulong> timestampSeconds)
		{
			this.XdrPermyriadPerIcp = xdrPermyriadPerIcp;
			this.TimestampSeconds = timestampSeconds;
		}

		public XdrConversionRate()
		{
		}
	}
}