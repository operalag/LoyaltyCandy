using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using System;
using Icrc1BlockIndex = EdjCase.ICP.Candid.Models.UnboundedUInt;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class TransferFromResult
	{
		[VariantTagProperty]
		public TransferFromResultTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public TransferFromResult(TransferFromResultTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected TransferFromResult()
		{
		}

		public static TransferFromResult Ok(Icrc1BlockIndex info)
		{
			return new TransferFromResult(TransferFromResultTag.Ok, info);
		}

		public static TransferFromResult Err(TransferFromError info)
		{
			return new TransferFromResult(TransferFromResultTag.Err, info);
		}

		public Icrc1BlockIndex AsOk()
		{
			this.ValidateTag(TransferFromResultTag.Ok);
			return (Icrc1BlockIndex)this.Value!;
		}

		public TransferFromError AsErr()
		{
			this.ValidateTag(TransferFromResultTag.Err);
			return (TransferFromError)this.Value!;
		}

		private void ValidateTag(TransferFromResultTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum TransferFromResultTag
	{
		Ok,
		Err
	}
}