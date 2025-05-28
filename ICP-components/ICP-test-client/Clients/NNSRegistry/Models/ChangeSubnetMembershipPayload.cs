using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class ChangeSubnetMembershipPayload
	{
		[CandidName("node_ids_add")]
		public List<Principal> NodeIdsAdd { get; set; }

		[CandidName("subnet_id")]
		public Principal SubnetId { get; set; }

		[CandidName("node_ids_remove")]
		public List<Principal> NodeIdsRemove { get; set; }

		public ChangeSubnetMembershipPayload(List<Principal> nodeIdsAdd, Principal subnetId, List<Principal> nodeIdsRemove)
		{
			this.NodeIdsAdd = nodeIdsAdd;
			this.SubnetId = subnetId;
			this.NodeIdsRemove = nodeIdsRemove;
		}

		public ChangeSubnetMembershipPayload()
		{
		}
	}
}