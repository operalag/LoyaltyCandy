using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class ProposalActionRequest
	{
		[VariantTagProperty]
		public ProposalActionRequestTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public ProposalActionRequest(ProposalActionRequestTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected ProposalActionRequest()
		{
		}

		public static ProposalActionRequest RegisterKnownNeuron(KnownNeuron info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.RegisterKnownNeuron, info);
		}

		public static ProposalActionRequest ManageNeuron(ManageNeuronRequest info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.ManageNeuron, info);
		}

		public static ProposalActionRequest UpdateCanisterSettings(UpdateCanisterSettings info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.UpdateCanisterSettings, info);
		}

		public static ProposalActionRequest InstallCode(InstallCodeRequest info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.InstallCode, info);
		}

		public static ProposalActionRequest StopOrStartCanister(StopOrStartCanister info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.StopOrStartCanister, info);
		}

		public static ProposalActionRequest CreateServiceNervousSystem(CreateServiceNervousSystem info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.CreateServiceNervousSystem, info);
		}

		public static ProposalActionRequest ExecuteNnsFunction(ExecuteNnsFunction info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.ExecuteNnsFunction, info);
		}

		public static ProposalActionRequest RewardNodeProvider(RewardNodeProvider info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.RewardNodeProvider, info);
		}

		public static ProposalActionRequest RewardNodeProviders(RewardNodeProviders info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.RewardNodeProviders, info);
		}

		public static ProposalActionRequest ManageNetworkEconomics(NetworkEconomics info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.ManageNetworkEconomics, info);
		}

		public static ProposalActionRequest ApproveGenesisKyc(Principals info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.ApproveGenesisKyc, info);
		}

		public static ProposalActionRequest AddOrRemoveNodeProvider(AddOrRemoveNodeProvider info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.AddOrRemoveNodeProvider, info);
		}

		public static ProposalActionRequest Motion(Motion info)
		{
			return new ProposalActionRequest(ProposalActionRequestTag.Motion, info);
		}

		public KnownNeuron AsRegisterKnownNeuron()
		{
			this.ValidateTag(ProposalActionRequestTag.RegisterKnownNeuron);
			return (KnownNeuron)this.Value!;
		}

		public ManageNeuronRequest AsManageNeuron()
		{
			this.ValidateTag(ProposalActionRequestTag.ManageNeuron);
			return (ManageNeuronRequest)this.Value!;
		}

		public UpdateCanisterSettings AsUpdateCanisterSettings()
		{
			this.ValidateTag(ProposalActionRequestTag.UpdateCanisterSettings);
			return (UpdateCanisterSettings)this.Value!;
		}

		public InstallCodeRequest AsInstallCode()
		{
			this.ValidateTag(ProposalActionRequestTag.InstallCode);
			return (InstallCodeRequest)this.Value!;
		}

		public StopOrStartCanister AsStopOrStartCanister()
		{
			this.ValidateTag(ProposalActionRequestTag.StopOrStartCanister);
			return (StopOrStartCanister)this.Value!;
		}

		public CreateServiceNervousSystem AsCreateServiceNervousSystem()
		{
			this.ValidateTag(ProposalActionRequestTag.CreateServiceNervousSystem);
			return (CreateServiceNervousSystem)this.Value!;
		}

		public ExecuteNnsFunction AsExecuteNnsFunction()
		{
			this.ValidateTag(ProposalActionRequestTag.ExecuteNnsFunction);
			return (ExecuteNnsFunction)this.Value!;
		}

		public RewardNodeProvider AsRewardNodeProvider()
		{
			this.ValidateTag(ProposalActionRequestTag.RewardNodeProvider);
			return (RewardNodeProvider)this.Value!;
		}

		public RewardNodeProviders AsRewardNodeProviders()
		{
			this.ValidateTag(ProposalActionRequestTag.RewardNodeProviders);
			return (RewardNodeProviders)this.Value!;
		}

		public NetworkEconomics AsManageNetworkEconomics()
		{
			this.ValidateTag(ProposalActionRequestTag.ManageNetworkEconomics);
			return (NetworkEconomics)this.Value!;
		}

		public Principals AsApproveGenesisKyc()
		{
			this.ValidateTag(ProposalActionRequestTag.ApproveGenesisKyc);
			return (Principals)this.Value!;
		}

		public AddOrRemoveNodeProvider AsAddOrRemoveNodeProvider()
		{
			this.ValidateTag(ProposalActionRequestTag.AddOrRemoveNodeProvider);
			return (AddOrRemoveNodeProvider)this.Value!;
		}

		public Motion AsMotion()
		{
			this.ValidateTag(ProposalActionRequestTag.Motion);
			return (Motion)this.Value!;
		}

		private void ValidateTag(ProposalActionRequestTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum ProposalActionRequestTag
	{
		RegisterKnownNeuron,
		ManageNeuron,
		UpdateCanisterSettings,
		InstallCode,
		StopOrStartCanister,
		CreateServiceNervousSystem,
		ExecuteNnsFunction,
		RewardNodeProvider,
		RewardNodeProviders,
		ManageNetworkEconomics,
		ApproveGenesisKyc,
		AddOrRemoveNodeProvider,
		Motion
	}
}