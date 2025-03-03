using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using EdjCase.ICP.Agent.Responses;
using EdjCase.ICP.Candid.Models.Values;

namespace LoyaltyCandy.HelloClient
{
	public class HelloClientApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public HelloClientApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task<string> Greet(string arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.Text(arg0));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "greet", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<string>(this.Converter);
		}
	}
}