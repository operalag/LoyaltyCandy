using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class GetSubnetForCanisterResponse
	{
		[VariantTagProperty]
		public GetSubnetForCanisterResponseTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public GetSubnetForCanisterResponse(GetSubnetForCanisterResponseTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected GetSubnetForCanisterResponse()
		{
		}

		public static GetSubnetForCanisterResponse Ok(GetSubnetForCanisterResponse.OkInfo info)
		{
			return new GetSubnetForCanisterResponse(GetSubnetForCanisterResponseTag.Ok, info);
		}

		public static GetSubnetForCanisterResponse Err(string info)
		{
			return new GetSubnetForCanisterResponse(GetSubnetForCanisterResponseTag.Err, info);
		}

		public GetSubnetForCanisterResponse.OkInfo AsOk()
		{
			this.ValidateTag(GetSubnetForCanisterResponseTag.Ok);
			return (GetSubnetForCanisterResponse.OkInfo)this.Value!;
		}

		public string AsErr()
		{
			this.ValidateTag(GetSubnetForCanisterResponseTag.Err);
			return (string)this.Value!;
		}

		private void ValidateTag(GetSubnetForCanisterResponseTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}

		public class OkInfo
		{
			[CandidName("subnet_id")]
			public OptionalValue<Principal> SubnetId { get; set; }

			public OkInfo(OptionalValue<Principal> subnetId)
			{
				this.SubnetId = subnetId;
			}

			public OkInfo()
			{
			}
		}
	}

	public enum GetSubnetForCanisterResponseTag
	{
		Ok,
		Err
	}
}