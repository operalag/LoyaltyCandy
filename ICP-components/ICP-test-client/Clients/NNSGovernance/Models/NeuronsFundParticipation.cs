using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundParticipation
	{
		[CandidName("total_maturity_equivalent_icp_e8s")]
		public OptionalValue<ulong> TotalMaturityEquivalentIcpE8s { get; set; }

		[CandidName("intended_neurons_fund_participation_icp_e8s")]
		public OptionalValue<ulong> IntendedNeuronsFundParticipationIcpE8s { get; set; }

		[CandidName("direct_participation_icp_e8s")]
		public OptionalValue<ulong> DirectParticipationIcpE8s { get; set; }

		[CandidName("swap_participation_limits")]
		public OptionalValue<SwapParticipationLimits> SwapParticipationLimits { get; set; }

		[CandidName("max_neurons_fund_swap_participation_icp_e8s")]
		public OptionalValue<ulong> MaxNeuronsFundSwapParticipationIcpE8s { get; set; }

		[CandidName("neurons_fund_reserves")]
		public OptionalValue<NeuronsFundSnapshot> NeuronsFundReserves { get; set; }

		[CandidName("ideal_matched_participation_function")]
		public OptionalValue<IdealMatchedParticipationFunction> IdealMatchedParticipationFunction { get; set; }

		[CandidName("allocated_neurons_fund_participation_icp_e8s")]
		public OptionalValue<ulong> AllocatedNeuronsFundParticipationIcpE8s { get; set; }

		public NeuronsFundParticipation(OptionalValue<ulong> totalMaturityEquivalentIcpE8s, OptionalValue<ulong> intendedNeuronsFundParticipationIcpE8s, OptionalValue<ulong> directParticipationIcpE8s, OptionalValue<SwapParticipationLimits> swapParticipationLimits, OptionalValue<ulong> maxNeuronsFundSwapParticipationIcpE8s, OptionalValue<NeuronsFundSnapshot> neuronsFundReserves, OptionalValue<IdealMatchedParticipationFunction> idealMatchedParticipationFunction, OptionalValue<ulong> allocatedNeuronsFundParticipationIcpE8s)
		{
			this.TotalMaturityEquivalentIcpE8s = totalMaturityEquivalentIcpE8s;
			this.IntendedNeuronsFundParticipationIcpE8s = intendedNeuronsFundParticipationIcpE8s;
			this.DirectParticipationIcpE8s = directParticipationIcpE8s;
			this.SwapParticipationLimits = swapParticipationLimits;
			this.MaxNeuronsFundSwapParticipationIcpE8s = maxNeuronsFundSwapParticipationIcpE8s;
			this.NeuronsFundReserves = neuronsFundReserves;
			this.IdealMatchedParticipationFunction = idealMatchedParticipationFunction;
			this.AllocatedNeuronsFundParticipationIcpE8s = allocatedNeuronsFundParticipationIcpE8s;
		}

		public NeuronsFundParticipation()
		{
		}
	}
}