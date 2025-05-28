using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListKnownNeuronsResponse
	{
		[CandidName("known_neurons")]
		public List<KnownNeuron> KnownNeurons { get; set; }

		public ListKnownNeuronsResponse(List<KnownNeuron> knownNeurons)
		{
			this.KnownNeurons = knownNeurons;
		}

		public ListKnownNeuronsResponse()
		{
		}
	}
}