using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Ok
	{
		[CandidName("neurons_fund_audit_info")]
		public OptionalValue<NeuronsFundAuditInfo> NeuronsFundAuditInfo { get; set; }

		public Ok(OptionalValue<NeuronsFundAuditInfo> neuronsFundAuditInfo)
		{
			this.NeuronsFundAuditInfo = neuronsFundAuditInfo;
		}

		public Ok()
		{
		}
	}
}