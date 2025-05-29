using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class TransferFee
	{
		[CandidName("transfer_fee")]
		public Tokens TransferFee_ { get; set; }

		public TransferFee(Tokens transferfee)
		{
			this.TransferFee_ = transferfee;
		}

		public TransferFee()
		{
		}
	}
}