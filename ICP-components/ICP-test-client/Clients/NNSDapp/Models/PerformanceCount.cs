using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class PerformanceCount
	{
		[CandidName("timestamp_ns_since_epoch")]
		public ulong TimestampNsSinceEpoch { get; set; }

		[CandidName("name")]
		public string Name { get; set; }

		[CandidName("instruction_count")]
		public ulong InstructionCount { get; set; }

		public PerformanceCount(ulong timestampNsSinceEpoch, string name, ulong instructionCount)
		{
			this.TimestampNsSinceEpoch = timestampNsSinceEpoch;
			this.Name = name;
			this.InstructionCount = instructionCount;
		}

		public PerformanceCount()
		{
		}
	}
}