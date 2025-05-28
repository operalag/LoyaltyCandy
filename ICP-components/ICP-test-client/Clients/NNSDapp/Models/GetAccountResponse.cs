using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSDapp.Models;
using System;

namespace LoyaltyCandy.NNSDapp.Models
{
	[Variant]
	public class GetAccountResponse
	{
		[VariantTagProperty]
		public GetAccountResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetAccountResponse(GetAccountResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetAccountResponse()
		{
		}

		public static GetAccountResponse Ok(AccountDetails info)
		{
			return new GetAccountResponse(GetAccountResponseTag.Ok, info);
		}

		public static GetAccountResponse AccountNotFound()
		{
			return new GetAccountResponse(GetAccountResponseTag.AccountNotFound, null);
		}

		public AccountDetails AsOk()
		{
			this.ValidateTag(GetAccountResponseTag.Ok);
			return (AccountDetails)this.Value!;
		}

		private void ValidateTag(GetAccountResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetAccountResponseTag
	{
		Ok,
		AccountNotFound
	}
}