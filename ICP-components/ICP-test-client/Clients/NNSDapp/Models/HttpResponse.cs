using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSDapp.Models;
using System.Collections.Generic;
using HeaderField = System.ValueTuple<System.String, System.String>;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class HttpResponse
	{
		[CandidName("status_code")]
		public ushort StatusCode { get; set; }

		[CandidName("headers")]
		public HttpResponse.HeadersInfo Headers { get; set; }

		[CandidName("body")]
		public List<byte> Body { get; set; }

		public HttpResponse(ushort statusCode, HttpResponse.HeadersInfo headers, List<byte> body)
		{
			this.StatusCode = statusCode;
			this.Headers = headers;
			this.Body = body;
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