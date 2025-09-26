using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class DeployGuestosToAllUnassignedNodesPayload
	{
		[CandidName("elected_replica_version")]
		public string ElectedReplicaVersion { get; set; }

		public DeployGuestosToAllUnassignedNodesPayload(string electedReplicaVersion)
		{
			this.ElectedReplicaVersion = electedReplicaVersion;
		}

		public DeployGuestosToAllUnassignedNodesPayload()
		{
		}
	}
}