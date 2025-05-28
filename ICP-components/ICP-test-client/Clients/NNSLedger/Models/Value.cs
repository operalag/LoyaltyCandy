using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using System;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class Value
	{
		[VariantTagProperty]
		public ValueTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value_ { get; set; }

		public Value(ValueTag tag, object? value)
		{
			this.Tag = tag;
			this.Value_ = value;
		}

		protected Value()
		{
		}

		public static Value Nat(UnboundedUInt info)
		{
			return new Value(ValueTag.Nat, info);
		}

		public static Value Int(UnboundedInt info)
		{
			return new Value(ValueTag.Int, info);
		}

		public static Value Text(string info)
		{
			return new Value(ValueTag.Text, info);
		}

		public static Value Blob(List<byte> info)
		{
			return new Value(ValueTag.Blob, info);
		}

		public UnboundedUInt AsNat()
		{
			this.ValidateTag(ValueTag.Nat);
			return (UnboundedUInt)this.Value_!;
		}

		public UnboundedInt AsInt()
		{
			this.ValidateTag(ValueTag.Int);
			return (UnboundedInt)this.Value_!;
		}

		public string AsText()
		{
			this.ValidateTag(ValueTag.Text);
			return (string)this.Value_!;
		}

		public List<byte> AsBlob()
		{
			this.ValidateTag(ValueTag.Blob);
			return (List<byte>)this.Value_!;
		}

		private void ValidateTag(ValueTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum ValueTag
	{
		Nat,
		Int,
		Text,
		Blob
	}
}