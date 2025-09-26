using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSCyclesMinting.Models;
using AccountIdentifier = System.String;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class CyclesCanisterInitPayload
	{
		[CandidName("ledger_canister_id")]
		public OptionalValue<Principal> LedgerCanisterId { get; set; }

		[CandidName("governance_canister_id")]
		public OptionalValue<Principal> GovernanceCanisterId { get; set; }

		[CandidName("minting_account_id")]
		public CyclesCanisterInitPayload.MintingAccountIdInfo MintingAccountId { get; set; }

		[CandidName("last_purged_notification")]
		public OptionalValue<ulong> LastPurgedNotification { get; set; }

		[CandidName("exchange_rate_canister")]
		public OptionalValue<ExchangeRateCanister> ExchangeRateCanister { get; set; }

		[CandidName("cycles_ledger_canister_id")]
		public OptionalValue<Principal> CyclesLedgerCanisterId { get; set; }

		public CyclesCanisterInitPayload(OptionalValue<Principal> ledgerCanisterId, OptionalValue<Principal> governanceCanisterId, CyclesCanisterInitPayload.MintingAccountIdInfo mintingAccountId, OptionalValue<ulong> lastPurgedNotification, OptionalValue<ExchangeRateCanister> exchangeRateCanister, OptionalValue<Principal> cyclesLedgerCanisterId)
		{
			this.LedgerCanisterId = ledgerCanisterId;
			this.GovernanceCanisterId = governanceCanisterId;
			this.MintingAccountId = mintingAccountId;
			this.LastPurgedNotification = lastPurgedNotification;
			this.ExchangeRateCanister = exchangeRateCanister;
			this.CyclesLedgerCanisterId = cyclesLedgerCanisterId;
		}

		public CyclesCanisterInitPayload()
		{
		}

		public class MintingAccountIdInfo : OptionalValue<AccountIdentifier>
		{
			public MintingAccountIdInfo()
			{
			}

			public MintingAccountIdInfo(AccountIdentifier value) : base(value)
			{
			}
		}
	}
}