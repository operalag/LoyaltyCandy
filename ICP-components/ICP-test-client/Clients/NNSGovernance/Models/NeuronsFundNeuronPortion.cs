using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundNeuronPortion
	{
		[CandidName("controller")]
		public OptionalValue<Principal> Controller { get; set; }

		[CandidName("hotkeys")]
		public List<Principal> Hotkeys { get; set; }

		[CandidName("is_capped")]
		public OptionalValue<bool> IsCapped { get; set; }

		[CandidName("maturity_equivalent_icp_e8s")]
		public OptionalValue<ulong> MaturityEquivalentIcpE8s { get; set; }

		[CandidName("nns_neuron_id")]
		public OptionalValue<NeuronId> NnsNeuronId { get; set; }

		[CandidName("amount_icp_e8s")]
		public OptionalValue<ulong> AmountIcpE8s { get; set; }

		public NeuronsFundNeuronPortion(OptionalValue<Principal> controller, List<Principal> hotkeys, OptionalValue<bool> isCapped, OptionalValue<ulong> maturityEquivalentIcpE8s, OptionalValue<NeuronId> nnsNeuronId, OptionalValue<ulong> amountIcpE8s)
		{
			this.Controller = controller;
			this.Hotkeys = hotkeys;
			this.IsCapped = isCapped;
			this.MaturityEquivalentIcpE8s = maturityEquivalentIcpE8s;
			this.NnsNeuronId = nnsNeuronId;
			this.AmountIcpE8s = amountIcpE8s;
		}

		public NeuronsFundNeuronPortion()
		{
		}
	}
}