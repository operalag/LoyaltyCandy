using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSGovernance.Models;

namespace LoyaltyCandy.NNSGovernance.Models
{
	public class DisburseMaturity
	{
		[CandidName("percentage_to_disburse")]
		public uint PercentageToDisburse { get; set; }

		[CandidName("to_account")]
		public OptionalValue<Account> ToAccount { get; set; }

		public DisburseMaturity(uint percentageToDisburse, OptionalValue<Account> toAccount)
		{
			this.PercentageToDisburse = percentageToDisburse;
			this.ToAccount = toAccount;
		}

		public DisburseMaturity()
		{
		}
	}
}