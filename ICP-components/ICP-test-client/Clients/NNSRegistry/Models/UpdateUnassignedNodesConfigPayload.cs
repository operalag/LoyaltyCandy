using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateUnassignedNodesConfigPayload
	{
		[CandidName("replica_version")]
		public OptionalValue<string> ReplicaVersion { get; set; }

		[CandidName("ssh_readonly_access")]
		public OptionalValue<List<string>> SshReadonlyAccess { get; set; }

		public UpdateUnassignedNodesConfigPayload(OptionalValue<string> replicaVersion, OptionalValue<List<string>> sshReadonlyAccess)
		{
			this.ReplicaVersion = replicaVersion;
			this.SshReadonlyAccess = sshReadonlyAccess;
		}

		public UpdateUnassignedNodesConfigPayload()
		{
		}
	}
}