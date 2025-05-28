using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class AddOrRemoveDataCentersProposalPayload
	{
		[CandidName("data_centers_to_add")]
		public List<DataCenterRecord> DataCentersToAdd { get; set; }

		[CandidName("data_centers_to_remove")]
		public List<string> DataCentersToRemove { get; set; }

		public AddOrRemoveDataCentersProposalPayload(List<DataCenterRecord> dataCentersToAdd, List<string> dataCentersToRemove)
		{
			this.DataCentersToAdd = dataCentersToAdd;
			this.DataCentersToRemove = dataCentersToRemove;
		}

		public AddOrRemoveDataCentersProposalPayload()
		{
		}
	}
}