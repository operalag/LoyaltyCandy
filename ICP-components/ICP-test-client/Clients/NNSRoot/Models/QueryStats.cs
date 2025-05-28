using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class QueryStats
	{
		[CandidName("num_calls_total")]
		public OptionalValue<UnboundedUInt> NumCallsTotal { get; set; }

		[CandidName("num_instructions_total")]
		public OptionalValue<UnboundedUInt> NumInstructionsTotal { get; set; }

		[CandidName("request_payload_bytes_total")]
		public OptionalValue<UnboundedUInt> RequestPayloadBytesTotal { get; set; }

		[CandidName("response_payload_bytes_total")]
		public OptionalValue<UnboundedUInt> ResponsePayloadBytesTotal { get; set; }

		public QueryStats(OptionalValue<UnboundedUInt> numCallsTotal, OptionalValue<UnboundedUInt> numInstructionsTotal, OptionalValue<UnboundedUInt> requestPayloadBytesTotal, OptionalValue<UnboundedUInt> responsePayloadBytesTotal)
		{
			this.NumCallsTotal = numCallsTotal;
			this.NumInstructionsTotal = numInstructionsTotal;
			this.RequestPayloadBytesTotal = requestPayloadBytesTotal;
			this.ResponsePayloadBytesTotal = responsePayloadBytesTotal;
		}

		public QueryStats()
		{
		}
	}
}