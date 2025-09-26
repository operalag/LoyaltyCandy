using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy.NNSRegistry.Models;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class DataCenterRecord
	{
		[CandidName("id")]
		public string Id { get; set; }

		[CandidName("gps")]
		public OptionalValue<Gps> Gps { get; set; }

		[CandidName("region")]
		public string Region { get; set; }

		[CandidName("owner")]
		public string Owner { get; set; }

		public DataCenterRecord(string id, OptionalValue<Gps> gps, string region, string owner)
		{
			this.Id = id;
			this.Gps = gps;
			this.Region = region;
			this.Owner = owner;
		}

		public DataCenterRecord()
		{
		}
	}
}