using EdjCase.ICP.Candid.Mapping;
using LoyaltyCandy.NNSDapp.Models;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using ConfigAtom = System.ValueTuple<System.String, System.String>;

namespace LoyaltyCandy.NNSDapp.Models
{
	public class Config
	{
		[CandidName("args")]
		public Config.ArgsInfo Args { get; set; }

		[CandidName("schema")]
		public OptionalValue<SchemaLabel> Schema { get; set; }

		public Config(Config.ArgsInfo args, OptionalValue<SchemaLabel> schema)
		{
			this.Args = args;
			this.Schema = schema;
		}

		public Config()
		{
		}

		public class ArgsInfo : List<ConfigAtom>
		{
			public ArgsInfo()
			{
			}
		}
	}
}