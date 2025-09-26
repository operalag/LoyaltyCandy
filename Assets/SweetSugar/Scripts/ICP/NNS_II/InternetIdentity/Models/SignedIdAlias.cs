using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;

namespace LoyaltyCandy.InternetIdentity.Models
{
	public class SignedIdAlias
	{
		[CandidName("credential_jws")]
		public string CredentialJws { get; set; }

		[CandidName("id_alias")]
		public Principal IdAlias { get; set; }

		[CandidName("id_dapp")]
		public Principal IdDapp { get; set; }

		public SignedIdAlias(string credentialJws, Principal idAlias, Principal idDapp)
		{
			this.CredentialJws = credentialJws;
			this.IdAlias = idAlias;
			this.IdDapp = idDapp;
		}

		public SignedIdAlias()
		{
		}
	}
}