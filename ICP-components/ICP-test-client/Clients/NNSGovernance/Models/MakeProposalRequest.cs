using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class MakeProposalRequest
	{
		[CandidName("url")]
		public string Url { get; set; }

		[CandidName("title")]
		public OptionalValue<string> Title { get; set; }

		[CandidName("action")]
		public OptionalValue<ProposalActionRequest> Action { get; set; }

		[CandidName("summary")]
		public string Summary { get; set; }

		public MakeProposalRequest(string url, OptionalValue<string> title, OptionalValue<ProposalActionRequest> action, string summary)
		{
			this.Url = url;
			this.Title = title;
			this.Action = action;
			this.Summary = summary;
		}

		public MakeProposalRequest()
		{
		}
	}
}