using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class RemoveNodeOperatorsPayload
	{
		[CandidName("node_operators_to_remove")]
		public List<List<byte>> NodeOperatorsToRemove { get; set; }

		[CandidName("node_operator_principals_to_remove")]
		public OptionalValue<NodeOperatorPrincipals> NodeOperatorPrincipalsToRemove { get; set; }

		public RemoveNodeOperatorsPayload(List<List<byte>> nodeOperatorsToRemove, OptionalValue<NodeOperatorPrincipals> nodeOperatorPrincipalsToRemove)
		{
			this.NodeOperatorsToRemove = nodeOperatorsToRemove;
			this.NodeOperatorPrincipalsToRemove = nodeOperatorPrincipalsToRemove;
		}

		public RemoveNodeOperatorsPayload()
		{
		}
	}
}