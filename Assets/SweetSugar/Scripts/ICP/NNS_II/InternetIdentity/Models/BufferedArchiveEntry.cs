using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using UserNumber = System.UInt64;
using Timestamp = System.UInt64;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class BufferedArchiveEntry
	{
		[CandidName("anchor_number")]
		public UserNumber AnchorNumber { get; set; }

		[CandidName("timestamp")]
		public Timestamp Timestamp { get; set; }

		[CandidName("sequence_number")]
		public ulong SequenceNumber { get; set; }

		[CandidName("entry")]
		public List<byte> Entry { get; set; }

		public BufferedArchiveEntry(UserNumber anchorNumber, Timestamp timestamp, ulong sequenceNumber, List<byte> entry)
		{
			this.AnchorNumber = anchorNumber;
			this.Timestamp = timestamp;
			this.SequenceNumber = sequenceNumber;
			this.Entry = entry;
		}

		public BufferedArchiveEntry()
		{
		}
	}
}