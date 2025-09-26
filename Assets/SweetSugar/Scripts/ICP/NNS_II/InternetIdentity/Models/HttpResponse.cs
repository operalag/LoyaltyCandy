using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;
using HeaderField = System.ValueTuple<System.String, System.String>;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class HttpResponse
	{
		[CandidName("status_code")]
		public ushort StatusCode { get; set; }

		[CandidName("headers")]
		public HttpResponse.HeadersInfo Headers { get; set; }

		[CandidName("body")]
		public List<byte> Body { get; set; }

		[CandidName("upgrade")]
		public OptionalValue<bool> Upgrade { get; set; }

		[CandidName("streaming_strategy")]
		public OptionalValue<StreamingStrategy> StreamingStrategy { get; set; }

		public HttpResponse(ushort statusCode, HttpResponse.HeadersInfo headers, List<byte> body, OptionalValue<bool> upgrade, OptionalValue<StreamingStrategy> streamingStrategy)
		{
			this.StatusCode = statusCode;
			this.Headers = headers;
			this.Body = body;
			this.Upgrade = upgrade;
			this.StreamingStrategy = streamingStrategy;
		}

		public HttpResponse()
		{
		}

		public class HeadersInfo : List<HeaderField>
		{
			public HeadersInfo()
			{
			}
		}
	}
}