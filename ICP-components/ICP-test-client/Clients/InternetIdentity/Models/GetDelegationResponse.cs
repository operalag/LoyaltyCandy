using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class GetDelegationResponse
	{
		[VariantTagProperty]
		public GetDelegationResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetDelegationResponse(GetDelegationResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetDelegationResponse()
		{
		}

		public static GetDelegationResponse SignedDelegation(SignedDelegation info)
		{
			return new GetDelegationResponse(GetDelegationResponseTag.SignedDelegation, info);
		}

		public static GetDelegationResponse NoSuchDelegation()
		{
			return new GetDelegationResponse(GetDelegationResponseTag.NoSuchDelegation, null);
		}

		public SignedDelegation AsSignedDelegation()
		{
			this.ValidateTag(GetDelegationResponseTag.SignedDelegation);
			return (SignedDelegation)this.Value!;
		}

		private void ValidateTag(GetDelegationResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetDelegationResponseTag
	{
		[CandidName("signed_delegation")]
		SignedDelegation,
		[CandidName("no_such_delegation")]
		NoSuchDelegation
	}
}