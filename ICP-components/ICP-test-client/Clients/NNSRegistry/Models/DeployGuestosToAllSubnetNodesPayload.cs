using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class DeployGuestosToAllSubnetNodesPayload
	{
		[CandidName("subnet_id")]
		public Principal SubnetId { get; set; }

		[CandidName("replica_version_id")]
		public string ReplicaVersionId { get; set; }

		public DeployGuestosToAllSubnetNodesPayload(Principal subnetId, string replicaVersionId)
		{
			this.SubnetId = subnetId;
			this.ReplicaVersionId = replicaVersionId;
		}

		public DeployGuestosToAllSubnetNodesPayload()
		{
		}
	}
}