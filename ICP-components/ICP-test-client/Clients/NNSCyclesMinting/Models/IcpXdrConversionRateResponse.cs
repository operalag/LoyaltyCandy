using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSCyclesMinting.Models;
using System.Collections.Generic;

namespace LoyaltyCandy.NNSCyclesMinting.Models
{
	public class IcpXdrConversionRateResponse
	{
		[CandidName("data")]
		public IcpXdrConversionRate Data { get; set; }

		[CandidName("hash_tree")]
		public List<byte> HashTree { get; set; }

		[CandidName("certificate")]
		public List<byte> Certificate { get; set; }

		public IcpXdrConversionRateResponse(IcpXdrConversionRate data, List<byte> hashTree, List<byte> certificate)
		{
			this.Data = data;
			this.HashTree = hashTree;
			this.Certificate = certificate;
		}

		public IcpXdrConversionRateResponse()
		{
		}
	}
}