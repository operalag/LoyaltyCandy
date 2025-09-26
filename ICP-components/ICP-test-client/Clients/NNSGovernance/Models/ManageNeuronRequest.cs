using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ManageNeuronRequest
	{
		[CandidName("id")]
		public OptionalValue<NeuronId> Id { get; set; }

		[CandidName("command")]
		public OptionalValue<ManageNeuronCommandRequest> Command { get; set; }

		[CandidName("neuron_id_or_subaccount")]
		public OptionalValue<NeuronIdOrSubaccount> NeuronIdOrSubaccount { get; set; }

		public ManageNeuronRequest(OptionalValue<NeuronId> id, OptionalValue<ManageNeuronCommandRequest> command, OptionalValue<NeuronIdOrSubaccount> neuronIdOrSubaccount)
		{
			this.Id = id;
			this.Command = command;
			this.NeuronIdOrSubaccount = neuronIdOrSubaccount;
		}

		public ManageNeuronRequest()
		{
		}
	}
}