using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class NeuronsFundEconomics
	{
		[CandidName("maximum_icp_xdr_rate")]
		public OptionalValue<Percentage> MaximumIcpXdrRate { get; set; }

		[CandidName("neurons_fund_matched_funding_curve_coefficients")]
		public OptionalValue<NeuronsFundMatchedFundingCurveCoefficients> NeuronsFundMatchedFundingCurveCoefficients { get; set; }

		[CandidName("max_theoretical_neurons_fund_participation_amount_xdr")]
		public OptionalValue<Decimal> MaxTheoreticalNeuronsFundParticipationAmountXdr { get; set; }

		[CandidName("minimum_icp_xdr_rate")]
		public OptionalValue<Percentage> MinimumIcpXdrRate { get; set; }

		public NeuronsFundEconomics(OptionalValue<Percentage> maximumIcpXdrRate, OptionalValue<NeuronsFundMatchedFundingCurveCoefficients> neuronsFundMatchedFundingCurveCoefficients, OptionalValue<Decimal> maxTheoreticalNeuronsFundParticipationAmountXdr, OptionalValue<Percentage> minimumIcpXdrRate)
		{
			this.MaximumIcpXdrRate = maximumIcpXdrRate;
			this.NeuronsFundMatchedFundingCurveCoefficients = neuronsFundMatchedFundingCurveCoefficients;
			this.MaxTheoreticalNeuronsFundParticipationAmountXdr = maxTheoreticalNeuronsFundParticipationAmountXdr;
			this.MinimumIcpXdrRate = minimumIcpXdrRate;
		}

		public NeuronsFundEconomics()
		{
		}
	}
}