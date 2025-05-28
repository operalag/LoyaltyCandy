using System.Collections.Generic;
using LoyaltyCandy.InternetIdentity.Models;
using EdjCase.ICP.Candid.Mapping;
using System;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class MetadataMap : List<MetadataMap.MetadataMapElement>
	{
		public MetadataMap()
		{
		}

		public class MetadataMapElement
		{
			[CandidTag(0U)]
			public string F0 { get; set; }

			[CandidTag(1U)]
			public MetadataMap.MetadataMapElement.F1Info F1 { get; set; }

			public MetadataMapElement(string f0, MetadataMap.MetadataMapElement.F1Info f1)
			{
				this.F0 = f0;
				this.F1 = f1;
			}

			public MetadataMapElement()
			{
			}

			[Variant]
			public class F1Info
			{
				[VariantTagProperty]
				public MetadataMap.MetadataMapElement.F1InfoTag Tag { get; set; }

				[VariantValueProperty]
				public object? Value { get; set; }

				public F1Info(MetadataMap.MetadataMapElement.F1InfoTag tag, object? value)
				{
					this.Tag = tag;
					this.Value = value;
				}

				protected F1Info()
				{
				}

				public static MetadataMap.MetadataMapElement.F1Info Map(MetadataMap info)
				{
					return new MetadataMap.MetadataMapElement.F1Info(MetadataMap.MetadataMapElement.F1InfoTag.Map, info);
				}

				public static MetadataMap.MetadataMapElement.F1Info String(string info)
				{
					return new MetadataMap.MetadataMapElement.F1Info(MetadataMap.MetadataMapElement.F1InfoTag.String, info);
				}

				public static MetadataMap.MetadataMapElement.F1Info Bytes(List<byte> info)
				{
					return new MetadataMap.MetadataMapElement.F1Info(MetadataMap.MetadataMapElement.F1InfoTag.Bytes, info);
				}

				public MetadataMap AsMap()
				{
					this.ValidateTag(MetadataMap.MetadataMapElement.F1InfoTag.Map);
					return (MetadataMap)this.Value!;
				}

				public string AsString()
				{
					this.ValidateTag(MetadataMap.MetadataMapElement.F1InfoTag.String);
					return (string)this.Value!;
				}

				public List<byte> AsBytes()
				{
					this.ValidateTag(MetadataMap.MetadataMapElement.F1InfoTag.Bytes);
					return (List<byte>)this.Value!;
				}

				private void ValidateTag(MetadataMap.MetadataMapElement.F1InfoTag tag)
				{
					if (!this.Tag.Equals(tag))
					{
						throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
					}
				}
			}

			public enum F1InfoTag
			{
				[CandidName("map")]
				Map,
				[CandidName("string")]
				String,
				[CandidName("bytes")]
				Bytes
			}
		}
	}
}