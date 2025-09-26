using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class GetIdAliasError
	{
		[VariantTagProperty]
		public GetIdAliasErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetIdAliasError(GetIdAliasErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetIdAliasError()
		{
		}

		public static GetIdAliasError Unauthorized(Principal info)
		{
			return new GetIdAliasError(GetIdAliasErrorTag.Unauthorized, info);
		}

		public static GetIdAliasError NoSuchCredentials(string info)
		{
			return new GetIdAliasError(GetIdAliasErrorTag.NoSuchCredentials, info);
		}

		public static GetIdAliasError InternalCanisterError(string info)
		{
			return new GetIdAliasError(GetIdAliasErrorTag.InternalCanisterError, info);
		}

		public Principal AsUnauthorized()
		{
			this.ValidateTag(GetIdAliasErrorTag.Unauthorized);
			return (Principal)this.Value!;
		}

		public string AsNoSuchCredentials()
		{
			this.ValidateTag(GetIdAliasErrorTag.NoSuchCredentials);
			return (string)this.Value!;
		}

		public string AsInternalCanisterError()
		{
			this.ValidateTag(GetIdAliasErrorTag.InternalCanisterError);
			return (string)this.Value!;
		}

		private void ValidateTag(GetIdAliasErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum GetIdAliasErrorTag
	{
		Unauthorized,
		NoSuchCredentials,
		InternalCanisterError
	}
}