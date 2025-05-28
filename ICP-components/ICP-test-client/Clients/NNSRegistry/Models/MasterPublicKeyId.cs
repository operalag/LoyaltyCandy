using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSRegistry.Models;
using System;

namespace LoyaltyCandy.NNSRegistry.Models
{
	[Variant]
	public class MasterPublicKeyId
	{
		[VariantTagProperty]
		public MasterPublicKeyIdTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public MasterPublicKeyId(MasterPublicKeyIdTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected MasterPublicKeyId()
		{
		}

		public static MasterPublicKeyId Schnorr(SchnorrKeyId info)
		{
			return new MasterPublicKeyId(MasterPublicKeyIdTag.Schnorr, info);
		}

		public static MasterPublicKeyId Ecdsa(EcdsaKeyId info)
		{
			return new MasterPublicKeyId(MasterPublicKeyIdTag.Ecdsa, info);
		}

		public static MasterPublicKeyId VetKd(VetKdKeyId info)
		{
			return new MasterPublicKeyId(MasterPublicKeyIdTag.VetKd, info);
		}

		public SchnorrKeyId AsSchnorr()
		{
			this.ValidateTag(MasterPublicKeyIdTag.Schnorr);
			return (SchnorrKeyId)this.Value!;
		}

		public EcdsaKeyId AsEcdsa()
		{
			this.ValidateTag(MasterPublicKeyIdTag.Ecdsa);
			return (EcdsaKeyId)this.Value!;
		}

		public VetKdKeyId AsVetKd()
		{
			this.ValidateTag(MasterPublicKeyIdTag.VetKd);
			return (VetKdKeyId)this.Value!;
		}

		private void ValidateTag(MasterPublicKeyIdTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum MasterPublicKeyIdTag
	{
		Schnorr,
		Ecdsa,
		VetKd
	}
}