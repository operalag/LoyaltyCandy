using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRoot.Models
{
	public class UpdateCanisterSettingsError
	{
		[CandidName("code")]
		public OptionalValue<int> Code { get; set; }

		[CandidName("description")]
		public string Description { get; set; }

		public UpdateCanisterSettingsError(OptionalValue<int> code, string description)
		{
			this.Code = code;
			this.Description = description;
		}

		public UpdateCanisterSettingsError()
		{
		}
	}
}