using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class ListNeurons
	{
		[CandidName("include_public_neurons_in_full_neurons")]
		public OptionalValue<bool> IncludePublicNeuronsInFullNeurons { get; set; }

		[CandidName("neuron_ids")]
		public List<ulong> NeuronIds { get; set; }

		[CandidName("include_empty_neurons_readable_by_caller")]
		public OptionalValue<bool> IncludeEmptyNeuronsReadableByCaller { get; set; }

		[CandidName("include_neurons_readable_by_caller")]
		public bool IncludeNeuronsReadableByCaller { get; set; }

		[CandidName("page_number")]
		public OptionalValue<ulong> PageNumber { get; set; }

		[CandidName("page_size")]
		public OptionalValue<ulong> PageSize { get; set; }

		[CandidName("neuron_subaccounts")]
		public OptionalValue<List<NeuronSubaccount>> NeuronSubaccounts { get; set; }

		public ListNeurons(OptionalValue<bool> includePublicNeuronsInFullNeurons, List<ulong> neuronIds, OptionalValue<bool> includeEmptyNeuronsReadableByCaller, bool includeNeuronsReadableByCaller, OptionalValue<ulong> pageNumber, OptionalValue<ulong> pageSize, OptionalValue<List<NeuronSubaccount>> neuronSubaccounts)
		{
			this.IncludePublicNeuronsInFullNeurons = includePublicNeuronsInFullNeurons;
			this.NeuronIds = neuronIds;
			this.IncludeEmptyNeuronsReadableByCaller = includeEmptyNeuronsReadableByCaller;
			this.IncludeNeuronsReadableByCaller = includeNeuronsReadableByCaller;
			this.PageNumber = pageNumber;
			this.PageSize = pageSize;
			this.NeuronSubaccounts = neuronSubaccounts;
		}

		public ListNeurons()
		{
		}
	}
}