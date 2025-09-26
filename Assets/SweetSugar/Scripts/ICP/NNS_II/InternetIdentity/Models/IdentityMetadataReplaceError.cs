using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class IdentityMetadataReplaceError
	{
		[VariantTagProperty]
		public IdentityMetadataReplaceErrorTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public IdentityMetadataReplaceError(IdentityMetadataReplaceErrorTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected IdentityMetadataReplaceError()
		{
		}

		public static IdentityMetadataReplaceError Unauthorized(Principal info)
		{
			return new IdentityMetadataReplaceError(IdentityMetadataReplaceErrorTag.Unauthorized, info);
		}

		public static IdentityMetadataReplaceError StorageSpaceExceeded(IdentityMetadataReplaceError.StorageSpaceExceededInfo info)
		{
			return new IdentityMetadataReplaceError(IdentityMetadataReplaceErrorTag.StorageSpaceExceeded, info);
		}

		public static IdentityMetadataReplaceError InternalCanisterError(string info)
		{
			return new IdentityMetadataReplaceError(IdentityMetadataReplaceErrorTag.InternalCanisterError, info);
		}

		public Principal AsUnauthorized()
		{
			this.ValidateTag(IdentityMetadataReplaceErrorTag.Unauthorized);
			return (Principal)this.Value!;
		}

		public IdentityMetadataReplaceError.StorageSpaceExceededInfo AsStorageSpaceExceeded()
		{
			this.ValidateTag(IdentityMetadataReplaceErrorTag.StorageSpaceExceeded);
			return (IdentityMetadataReplaceError.StorageSpaceExceededInfo)this.Value!;
		}

		public string AsInternalCanisterError()
		{
			this.ValidateTag(IdentityMetadataReplaceErrorTag.InternalCanisterError);
			return (string)this.Value!;
		}

		private void ValidateTag(IdentityMetadataReplaceErrorTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class StorageSpaceExceededInfo
		{
			[CandidName("space_available")]
			public ulong SpaceAvailable { get; set; }

			[CandidName("space_required")]
			public ulong SpaceRequired { get; set; }

			public StorageSpaceExceededInfo(ulong spaceAvailable, ulong spaceRequired)
			{
				this.SpaceAvailable = spaceAvailable;
				this.SpaceRequired = spaceRequired;
			}

			public StorageSpaceExceededInfo()
			{
			}
		}
	}

	public enum IdentityMetadataReplaceErrorTag
	{
		Unauthorized,
		StorageSpaceExceeded,
		InternalCanisterError
	}
}