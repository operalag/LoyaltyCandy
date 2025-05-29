using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSLedger.Models;
using System;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSLedger.Models
{
	[Variant]
	public class Icrc21ConsentMessage
	{
		[VariantTagProperty]
		public Icrc21ConsentMessageTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public Icrc21ConsentMessage(Icrc21ConsentMessageTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected Icrc21ConsentMessage()
		{
		}

		public static Icrc21ConsentMessage GenericDisplayMessage(string info)
		{
			return new Icrc21ConsentMessage(Icrc21ConsentMessageTag.GenericDisplayMessage, info);
		}

		public static Icrc21ConsentMessage LineDisplayMessage(Icrc21ConsentMessage.LineDisplayMessageInfo info)
		{
			return new Icrc21ConsentMessage(Icrc21ConsentMessageTag.LineDisplayMessage, info);
		}

		public string AsGenericDisplayMessage()
		{
			this.ValidateTag(Icrc21ConsentMessageTag.GenericDisplayMessage);
			return (string)this.Value!;
		}

		public Icrc21ConsentMessage.LineDisplayMessageInfo AsLineDisplayMessage()
		{
			this.ValidateTag(Icrc21ConsentMessageTag.LineDisplayMessage);
			return (Icrc21ConsentMessage.LineDisplayMessageInfo)this.Value!;
		}

		private void ValidateTag(Icrc21ConsentMessageTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class LineDisplayMessageInfo
		{
			[CandidName("pages")]
			public List<Icrc21ConsentMessage.LineDisplayMessageInfo.PagesItem> Pages { get; set; }

			public LineDisplayMessageInfo(List<Icrc21ConsentMessage.LineDisplayMessageInfo.PagesItem> pages)
			{
				this.Pages = pages;
			}

			public LineDisplayMessageInfo()
			{
			}

			public class PagesItem
			{
				[CandidName("lines")]
				public List<string> Lines { get; set; }

				public PagesItem(List<string> lines)
				{
					this.Lines = lines;
				}

				public PagesItem()
				{
				}
			}
		}
	}

	public enum Icrc21ConsentMessageTag
	{
		GenericDisplayMessage,
		LineDisplayMessage
	}
}