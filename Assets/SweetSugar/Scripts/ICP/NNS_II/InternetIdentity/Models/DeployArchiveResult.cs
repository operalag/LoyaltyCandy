using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	[Variant]
	public class DeployArchiveResult
	{
		[VariantTagProperty]
		public DeployArchiveResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public DeployArchiveResult(DeployArchiveResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected DeployArchiveResult()
		{
		}

		public static DeployArchiveResult Success(Principal info)
		{
			return new DeployArchiveResult(DeployArchiveResultTag.Success, info);
		}

		public static DeployArchiveResult CreationInProgress()
		{
			return new DeployArchiveResult(DeployArchiveResultTag.CreationInProgress, null);
		}

		public static DeployArchiveResult Failed(string info)
		{
			return new DeployArchiveResult(DeployArchiveResultTag.Failed, info);
		}

		public Principal AsSuccess()
		{
			this.ValidateTag(DeployArchiveResultTag.Success);
			return (Principal)this.Value!;
		}

		public string AsFailed()
		{
			this.ValidateTag(DeployArchiveResultTag.Failed);
			return (string)this.Value!;
		}

		private void ValidateTag(DeployArchiveResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum DeployArchiveResultTag
	{
		[CandidName("success")]
		Success,
		[CandidName("creation_in_progress")]
		CreationInProgress,
		[CandidName("failed")]
		Failed
	}
}