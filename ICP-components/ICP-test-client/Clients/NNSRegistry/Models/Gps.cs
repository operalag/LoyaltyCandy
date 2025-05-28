using EdjCase.ICP.Candid.Mapping;

namespace LoyaltyCandy.NNSRegistry.Models
{
	public class Gps
	{
		[CandidName("latitude")]
		public float Latitude { get; set; }

		[CandidName("longitude")]
		public float Longitude { get; set; }

		public Gps(float latitude, float longitude)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
		}

		public Gps()
		{
		}
	}
}