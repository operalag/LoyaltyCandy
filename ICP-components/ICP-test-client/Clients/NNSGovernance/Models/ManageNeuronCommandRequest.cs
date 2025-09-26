using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSGovernance.Models;
using System;

namespace LoyaltyCandy.NNSGovernance.Models
{
	[Variant]
	public class ManageNeuronCommandRequest
	{
		[VariantTagProperty]
		public ManageNeuronCommandRequestTag Tag { get; set; }

		[VariantValueProperty]
		public object? Value { get; set; }

		public ManageNeuronCommandRequest(ManageNeuronCommandRequestTag tag, object? value)
		{
			this.Tag = tag;
			this.Value = value;
		}

		protected ManageNeuronCommandRequest()
		{
		}

		public static ManageNeuronCommandRequest Spawn(Spawn info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.Spawn, info);
		}

		public static ManageNeuronCommandRequest Split(Split info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.Split, info);
		}

		public static ManageNeuronCommandRequest Follow(Follow info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.Follow, info);
		}

		public static ManageNeuronCommandRequest ClaimOrRefresh(ClaimOrRefresh info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.ClaimOrRefresh, info);
		}

		public static ManageNeuronCommandRequest Configure(Configure info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.Configure, info);
		}

		public static ManageNeuronCommandRequest RegisterVote(RegisterVote info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.RegisterVote, info);
		}

		public static ManageNeuronCommandRequest Merge(Merge info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.Merge, info);
		}

		public static ManageNeuronCommandRequest DisburseToNeuron(DisburseToNeuron info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.DisburseToNeuron, info);
		}

		public static ManageNeuronCommandRequest MakeProposal(MakeProposalRequest info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.MakeProposal, info);
		}

		public static ManageNeuronCommandRequest StakeMaturity(StakeMaturity info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.StakeMaturity, info);
		}

		public static ManageNeuronCommandRequest MergeMaturity(MergeMaturity info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.MergeMaturity, info);
		}

		public static ManageNeuronCommandRequest Disburse(Disburse info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.Disburse, info);
		}

		public static ManageNeuronCommandRequest RefreshVotingPower(RefreshVotingPower info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.RefreshVotingPower, info);
		}

		public static ManageNeuronCommandRequest DisburseMaturity(DisburseMaturity info)
		{
			return new ManageNeuronCommandRequest(ManageNeuronCommandRequestTag.DisburseMaturity, info);
		}

		public Spawn AsSpawn()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.Spawn);
			return (Spawn)this.Value!;
		}

		public Split AsSplit()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.Split);
			return (Split)this.Value!;
		}

		public Follow AsFollow()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.Follow);
			return (Follow)this.Value!;
		}

		public ClaimOrRefresh AsClaimOrRefresh()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.ClaimOrRefresh);
			return (ClaimOrRefresh)this.Value!;
		}

		public Configure AsConfigure()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.Configure);
			return (Configure)this.Value!;
		}

		public RegisterVote AsRegisterVote()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.RegisterVote);
			return (RegisterVote)this.Value!;
		}

		public Merge AsMerge()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.Merge);
			return (Merge)this.Value!;
		}

		public DisburseToNeuron AsDisburseToNeuron()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.DisburseToNeuron);
			return (DisburseToNeuron)this.Value!;
		}

		public MakeProposalRequest AsMakeProposal()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.MakeProposal);
			return (MakeProposalRequest)this.Value!;
		}

		public StakeMaturity AsStakeMaturity()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.StakeMaturity);
			return (StakeMaturity)this.Value!;
		}

		public MergeMaturity AsMergeMaturity()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.MergeMaturity);
			return (MergeMaturity)this.Value!;
		}

		public Disburse AsDisburse()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.Disburse);
			return (Disburse)this.Value!;
		}

		public RefreshVotingPower AsRefreshVotingPower()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.RefreshVotingPower);
			return (RefreshVotingPower)this.Value!;
		}

		public DisburseMaturity AsDisburseMaturity()
		{
			this.ValidateTag(ManageNeuronCommandRequestTag.DisburseMaturity);
			return (DisburseMaturity)this.Value!;
		}

		private void ValidateTag(ManageNeuronCommandRequestTag tag)
		{
			if (!this.Tag.Equals(tag))
			{
				throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
			}
		}
	}

	public enum ManageNeuronCommandRequestTag
	{
		Spawn,
		Split,
		Follow,
		ClaimOrRefresh,
		Configure,
		RegisterVote,
		Merge,
		DisburseToNeuron,
		MakeProposal,
		StakeMaturity,
		MergeMaturity,
		Disburse,
		RefreshVotingPower,
		DisburseMaturity
	}
}