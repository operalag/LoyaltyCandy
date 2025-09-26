using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGenesisToken.Models;

namespace LoyaltyCandy.NNSGenesisToken.Models
{
	public class TransferredNeuron
	{
		[CandidName("error")]
		public OptionalValue<string> Error { get; set; }

		[CandidName("timestamp_seconds")]
		public ulong TimestampSeconds { get; set; }

		[CandidName("neuron_id")]
		public OptionalValue<NeuronId> NeuronId { get; set; }

		public TransferredNeuron(OptionalValue<string> error, ulong timestampSeconds, OptionalValue<NeuronId> neuronId)
		{
			this.Error = error;
			this.TimestampSeconds = timestampSeconds;
			this.NeuronId = neuronId;
		}

		public TransferredNeuron()
		{
		}
	}
}