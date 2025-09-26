using System.Collections.Generic;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Mapping;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class MetadataMapV2 : List<MetadataMapV2.MetadataMapV2Element>
	{
		public MetadataMapV2()
		{
		}

		public class MetadataMapV2Element
		{
			[CandidTag(0U)]
			public string F0 { get; set; }

			[CandidTag(1U)]
			public MetadataMapV2.MetadataMapV2Element.F1Info F1 { get; set; }

			public MetadataMapV2Element(string f0, MetadataMapV2.MetadataMapV2Element.F1Info f1)
			{
				this.F0 = f0;
				this.F1 = f1;
			}

			public MetadataMapV2Element()
			{
			}

			[Variant]
			public class F1Info
			{
				[VariantTagProperty]
				public MetadataMapV2.MetadataMapV2Element.F1InfoTag Tag { get; set; }

				[VariantValueProperty]
				public object? Value { get; set; }

				public F1Info(MetadataMapV2.MetadataMapV2Element.F1InfoTag tag, object? value)
				{
					this.Tag = tag;
					this.Value = value;
				}

				protected F1Info()
				{
				}

				public static MetadataMapV2.MetadataMapV2Element.F1Info Map(MetadataMapV2 info)
				{
					return new MetadataMapV2.MetadataMapV2Element.F1Info(MetadataMapV2.MetadataMapV2Element.F1InfoTag.Map, info);
				}

				public static MetadataMapV2.MetadataMapV2Element.F1Info String(string info)
				{
					return new MetadataMapV2.MetadataMapV2Element.F1Info(MetadataMapV2.MetadataMapV2Element.F1InfoTag.String, info);
				}

				public static MetadataMapV2.MetadataMapV2Element.F1Info Bytes(List<byte> info)
				{
					return new MetadataMapV2.MetadataMapV2Element.F1Info(MetadataMapV2.MetadataMapV2Element.F1InfoTag.Bytes, info);
				}

				public MetadataMapV2 AsMap()
				{
					this.ValidateTag(MetadataMapV2.MetadataMapV2Element.F1InfoTag.Map);
					return (MetadataMapV2)this.Value!;
				}

				public string AsString()
				{
					this.ValidateTag(MetadataMapV2.MetadataMapV2Element.F1InfoTag.String);
					return (string)this.Value!;
				}

				public List<byte> AsBytes()
				{
					this.ValidateTag(MetadataMapV2.MetadataMapV2Element.F1InfoTag.Bytes);
					return (List<byte>)this.Value!;
				}

				private void ValidateTag(MetadataMapV2.MetadataMapV2Element.F1InfoTag tag)
				{
					if (!this.Tag.Equals(tag))
					{
						throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
					}
				}
			}

			public enum F1InfoTag
			{
				Map,
				String,
				Bytes
			}
		}
	}
}