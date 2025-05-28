using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSDapp.Models;
using System;

namespace LoyaltyCandy.NNSDapp.Models
{
	[Variant]
	public class CreateSubAccountResponse
	{
		[VariantTagProperty]
		public CreateSubAccountResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public CreateSubAccountResponse(CreateSubAccountResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected CreateSubAccountResponse()
		{
		}

		public static CreateSubAccountResponse Ok(SubAccountDetails info)
		{
			return new CreateSubAccountResponse(CreateSubAccountResponseTag.Ok, info);
		}

		public static CreateSubAccountResponse AccountNotFound()
		{
			return new CreateSubAccountResponse(CreateSubAccountResponseTag.AccountNotFound, null);
		}

		public static CreateSubAccountResponse SubAccountLimitExceeded()
		{
			return new CreateSubAccountResponse(CreateSubAccountResponseTag.SubAccountLimitExceeded, null);
		}

		public static CreateSubAccountResponse NameTooLong()
		{
			return new CreateSubAccountResponse(CreateSubAccountResponseTag.NameTooLong, null);
		}

		public SubAccountDetails AsOk()
		{
			this.ValidateTag(CreateSubAccountResponseTag.Ok);
			return (SubAccountDetails)this.Value!;
		}

		private void ValidateTag(CreateSubAccountResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum CreateSubAccountResponseTag
	{
		Ok,
		AccountNotFound,
		SubAccountLimitExceeded,
		NameTooLong
	}
}