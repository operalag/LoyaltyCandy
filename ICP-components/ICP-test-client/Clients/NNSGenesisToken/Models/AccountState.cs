using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using LoyaltyCandy.NNSGenesisToken.Models;

namespace LoyaltyCandy.NNSGenesisToken.Models
{
	public class AccountState
	{
		[CandidName("authenticated_principal_id")]
		public OptionalValue<Principal> AuthenticatedPrincipalId { get; set; }

		[CandidName("successfully_transferred_neurons")]
		public List<TransferredNeuron> SuccessfullyTransferredNeurons { get; set; }

		[CandidName("is_whitelisted_for_forwarding")]
		public bool IsWhitelistedForForwarding { get; set; }

		[CandidName("has_donated")]
		public bool HasDonated { get; set; }

		[CandidName("failed_transferred_neurons")]
		public List<TransferredNeuron> FailedTransferredNeurons { get; set; }

		[CandidName("neuron_ids")]
		public List<NeuronId> NeuronIds { get; set; }

		[CandidName("has_claimed")]
		public bool HasClaimed { get; set; }

		[CandidName("has_forwarded")]
		public bool HasForwarded { get; set; }

		[CandidName("icpts")]
		public uint Icpts { get; set; }

		public AccountState(OptionalValue<Principal> authenticatedPrincipalId, List<TransferredNeuron> successfullyTransferredNeurons, bool isWhitelistedForForwarding, bool hasDonated, List<TransferredNeuron> failedTransferredNeurons, List<NeuronId> neuronIds, bool hasClaimed, bool hasForwarded, uint icpts)
		{
			this.AuthenticatedPrincipalId = authenticatedPrincipalId;
			this.SuccessfullyTransferredNeurons = successfullyTransferredNeurons;
			this.IsWhitelistedForForwarding = isWhitelistedForForwarding;
			this.HasDonated = hasDonated;
			this.FailedTransferredNeurons = failedTransferredNeurons;
			this.NeuronIds = neuronIds;
			this.HasClaimed = hasClaimed;
			this.HasForwarded = hasForwarded;
			this.Icpts = icpts;
		}

		public AccountState()
		{
		}
	}
}