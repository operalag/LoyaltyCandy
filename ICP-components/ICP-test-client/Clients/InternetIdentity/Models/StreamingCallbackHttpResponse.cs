using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.InternetIdentity.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class StreamingCallbackHttpResponse
	{
		[CandidName("body")]
		public List<byte> Body { get; set; }

		[CandidName("token")]
		public OptionalValue<Token> Token { get; set; }

		public StreamingCallbackHttpResponse(List<byte> body, OptionalValue<Token> token)
		{
			this.Body = body;
			this.Token = token;
		}

		public StreamingCallbackHttpResponse()
		{
		}
	}
}