using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using EdjCase.ICP.Candid.Models;
using System;

namespace LoyaltyCandy.NNSLedger.Models
{
	public class Icrc21ConsentMessageSpec
	{
		[CandidName("metadata")]
		public Icrc21ConsentMessageMetadata Metadata { get; set; }

		[CandidName("device_spec")]
		public OptionalValue<Icrc21ConsentMessageSpec.DeviceSpecValue> DeviceSpec { get; set; }

		public Icrc21ConsentMessageSpec(Icrc21ConsentMessageMetadata metadata, OptionalValue<Icrc21ConsentMessageSpec.DeviceSpecValue> deviceSpec)
		{
			this.Metadata = metadata;
			this.DeviceSpec = deviceSpec;
		}

		public Icrc21ConsentMessageSpec()
		{
		}

		[Variant]
		public class DeviceSpecValue
		{
			[VariantTagProperty]
			public Icrc21ConsentMessageSpec.DeviceSpecValueTag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public DeviceSpecValue(Icrc21ConsentMessageSpec.DeviceSpecValueTag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected DeviceSpecValue()
			{
			}

			public static Icrc21ConsentMessageSpec.DeviceSpecValue GenericDisplay()
			{
				return new Icrc21ConsentMessageSpec.DeviceSpecValue(Icrc21ConsentMessageSpec.DeviceSpecValueTag.GenericDisplay, null);
			}

			public static Icrc21ConsentMessageSpec.DeviceSpecValue LineDisplay(Icrc21ConsentMessageSpec.DeviceSpecValue.LineDisplayInfo info)
			{
				return new Icrc21ConsentMessageSpec.DeviceSpecValue(Icrc21ConsentMessageSpec.DeviceSpecValueTag.LineDisplay, info);
			}

			public Icrc21ConsentMessageSpec.DeviceSpecValue.LineDisplayInfo AsLineDisplay()
			{
				this.ValidateTag(Icrc21ConsentMessageSpec.DeviceSpecValueTag.LineDisplay);
				return (Icrc21ConsentMessageSpec.DeviceSpecValue.LineDisplayInfo)this.Value!;
			}

			private void ValidateTag(Icrc21ConsentMessageSpec.DeviceSpecValueTag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}

			public class LineDisplayInfo
			{
				[CandidName("characters_per_line")]
				public ushort CharactersPerLine { get; set; }

				[CandidName("lines_per_page")]
				public ushort LinesPerPage { get; set; }

				public LineDisplayInfo(ushort charactersPerLine, ushort linesPerPage)
				{
					this.CharactersPerLine = charactersPerLine;
					this.LinesPerPage = linesPerPage;
				}

				public LineDisplayInfo()
				{
				}
			}
		}

		public enum DeviceSpecValueTag
		{
			GenericDisplay,
			LineDisplay
		}
	}
}