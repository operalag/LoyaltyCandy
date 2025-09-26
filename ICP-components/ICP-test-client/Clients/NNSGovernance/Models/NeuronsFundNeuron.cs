using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundNeuron
	{
		[CandidName("controller")]
		public OptionalValue<Principal> Controller { get; set; }

		[CandidName("hotkeys")]
		public OptionalValue<Principals> Hotkeys { get; set; }

		[CandidName("is_capped")]
		public OptionalValue<bool> IsCapped { get; set; }

		[CandidName("nns_neuron_id")]
		public OptionalValue<ulong> NnsNeuronId { get; set; }

		[CandidName("amount_icp_e8s")]
		public OptionalValue<ulong> AmountIcpE8s { get; set; }

		public NeuronsFundNeuron(OptionalValue<Principal> controller, OptionalValue<Principals> hotkeys, OptionalValue<bool> isCapped, OptionalValue<ulong> nnsNeuronId, OptionalValue<ulong> amountIcpE8s)
		{
			this.Controller = controller;
			this.Hotkeys = hotkeys;
			this.IsCapped = isCapped;
			this.NnsNeuronId = nnsNeuronId;
			this.AmountIcpE8s = amountIcpE8s;
		}

		public NeuronsFundNeuron()
		{
		}
	}
}