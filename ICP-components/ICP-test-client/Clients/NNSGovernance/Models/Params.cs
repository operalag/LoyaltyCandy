using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class Params
	{
		[CandidName("min_participant_icp_e8s")]
		public ulong MinParticipantIcpE8s { get; set; }

		[CandidName("neuron_basket_construction_parameters")]
		public OptionalValue<Neuronbasketconstructionparameters1> NeuronBasketConstructionParameters { get; set; }

		[CandidName("max_icp_e8s")]
		public ulong MaxIcpE8s { get; set; }

		[CandidName("swap_due_timestamp_seconds")]
		public ulong SwapDueTimestampSeconds { get; set; }

		[CandidName("min_participants")]
		public uint MinParticipants { get; set; }

		[CandidName("sns_token_e8s")]
		public ulong SnsTokenE8s { get; set; }

		[CandidName("sale_delay_seconds")]
		public OptionalValue<ulong> SaleDelaySeconds { get; set; }

		[CandidName("max_participant_icp_e8s")]
		public ulong MaxParticipantIcpE8s { get; set; }

		[CandidName("min_direct_participation_icp_e8s")]
		public OptionalValue<ulong> MinDirectParticipationIcpE8s { get; set; }

		[CandidName("min_icp_e8s")]
		public ulong MinIcpE8s { get; set; }

		[CandidName("max_direct_participation_icp_e8s")]
		public OptionalValue<ulong> MaxDirectParticipationIcpE8s { get; set; }

		public Params(ulong minParticipantIcpE8s, OptionalValue<Neuronbasketconstructionparameters1> neuronBasketConstructionParameters, ulong maxIcpE8s, ulong swapDueTimestampSeconds, uint minParticipants, ulong snsTokenE8s, OptionalValue<ulong> saleDelaySeconds, ulong maxParticipantIcpE8s, OptionalValue<ulong> minDirectParticipationIcpE8s, ulong minIcpE8s, OptionalValue<ulong> maxDirectParticipationIcpE8s)
		{
			this.MinParticipantIcpE8s = minParticipantIcpE8s;
			this.NeuronBasketConstructionParameters = neuronBasketConstructionParameters;
			this.MaxIcpE8s = maxIcpE8s;
			this.SwapDueTimestampSeconds = swapDueTimestampSeconds;
			this.MinParticipants = minParticipants;
			this.SnsTokenE8s = snsTokenE8s;
			this.SaleDelaySeconds = saleDelaySeconds;
			this.MaxParticipantIcpE8s = maxParticipantIcpE8s;
			this.MinDirectParticipationIcpE8s = minDirectParticipationIcpE8s;
			this.MinIcpE8s = minIcpE8s;
			this.MaxDirectParticipationIcpE8s = maxDirectParticipationIcpE8s;
		}

		public Params()
		{
		}
	}
}