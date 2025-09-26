using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ClaimOrRefreshResponse
	{
		[CandidName("refreshed_neuron_id")]
		public OptionalValue<NeuronId> RefreshedNeuronId { get; set; }

		public ClaimOrRefreshResponse(OptionalValue<NeuronId> refreshedNeuronId)
		{
			this.RefreshedNeuronId = refreshedNeuronId;
		}

		public ClaimOrRefreshResponse()
		{
		}
	}
}