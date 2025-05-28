using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Image
	{
		[CandidName("base64_encoding")]
		public OptionalValue<string> Base64Encoding { get; set; }

		public Image(OptionalValue<string> base64Encoding)
		{
			this.Base64Encoding = base64Encoding;
		}

		public Image()
		{
		}
	}
}