using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class UpdateSshReadOnlyAccessForAllUnassignedNodesPayload
	{
		[CandidName("ssh_readonly_keys")]
		public List<string> SshReadonlyKeys { get; set; }

		public UpdateSshReadOnlyAccessForAllUnassignedNodesPayload(List<string> sshReadonlyKeys)
		{
			this.SshReadonlyKeys = sshReadonlyKeys;
		}

		public UpdateSshReadOnlyAccessForAllUnassignedNodesPayload()
		{
		}
	}
}