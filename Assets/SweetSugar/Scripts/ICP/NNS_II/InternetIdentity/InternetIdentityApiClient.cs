using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Candid.Models;
using EdjCase.ICP.Candid;
using System.Threading.Tasks;
using LoyaltyCandy.InternetIdentity;
using System.Collections.Generic;
using EdjCase.ICP.Agent.Responses;
using EdjCase.ICP.Candid.Mapping;
using System;
using UserNumber = System.UInt64;
using PublicKey = System.Collections.Generic.List<System.Byte>;
using DeviceKey = System.Collections.Generic.List<System.Byte>;
using UserKey = System.Collections.Generic.List<System.Byte>;
using SessionKey = System.Collections.Generic.List<System.Byte>;
using FrontendHostname = System.String;
using Timestamp = System.UInt64;
using CaptchaResult = LoyaltyCandy.InternetIdentity.Models.ChallengeResult;
using IdentityNumber = System.UInt64;

namespace LoyaltyCandy.InternetIdentity
{
	public class InternetIdentityApiClient
	{
		public IAgent Agent { get; }
		public Principal CanisterId { get; }
		public CandidConverter? Converter { get; }

		public InternetIdentityApiClient(IAgent agent, Principal canisterId, CandidConverter? converter = default)
		{
			this.Agent = agent;
			this.CanisterId = canisterId;
			this.Converter = converter;
		}

		public async Task InitSalt()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "init_salt", arg);
		}

		public async Task<Models.Challenge> CreateChallenge()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "create_challenge", arg);
			return reply.ToObjects<Models.Challenge>(this.Converter);
		}

		public async Task<Models.RegisterResponse> Register(Models.DeviceData arg0, Models.ChallengeResult arg1, OptionalValue<Principal> arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "register", arg);
			return reply.ToObjects<Models.RegisterResponse>(this.Converter);
		}

		public async Task Add(UserNumber arg0, Models.DeviceData arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "add", arg);
		}

		public async Task Update(UserNumber arg0, DeviceKey arg1, Models.DeviceData arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "update", arg);
		}

		public async Task Replace(UserNumber arg0, DeviceKey arg1, Models.DeviceData arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "replace", arg);
		}

		public async Task Remove(UserNumber arg0, DeviceKey arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "remove", arg);
		}

		public async Task<List<Models.DeviceData>> Lookup(UserNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "lookup", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<List<Models.DeviceData>>(this.Converter);
		}

		public async Task<Models.AnchorCredentials> GetAnchorCredentials(UserNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_anchor_credentials", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.AnchorCredentials>(this.Converter);
		}

		public async Task<Models.IdentityAnchorInfo> GetAnchorInfo(UserNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "get_anchor_info", arg);
			return reply.ToObjects<Models.IdentityAnchorInfo>(this.Converter);
		}

		public async Task<Principal> GetPrincipal(UserNumber arg0, FrontendHostname arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_principal", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Principal>(this.Converter);
		}

		public async Task<Models.InternetIdentityStats> Stats()
		{
			CandidArg arg = CandidArg.FromCandid();
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "stats", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.InternetIdentityStats>(this.Converter);
		}

		public async Task<Timestamp> EnterDeviceRegistrationMode(UserNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "enter_device_registration_mode", arg);
			return reply.ToObjects<Timestamp>(this.Converter);
		}

		public async Task ExitDeviceRegistrationMode(UserNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "exit_device_registration_mode", arg);
		}

		public async Task<Models.AddTentativeDeviceResponse> AddTentativeDevice(UserNumber arg0, Models.DeviceData arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "add_tentative_device", arg);
			return reply.ToObjects<Models.AddTentativeDeviceResponse>(this.Converter);
		}

		public async Task<Models.VerifyTentativeDeviceResponse> VerifyTentativeDevice(UserNumber arg0, string verificationCode)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(verificationCode, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "verify_tentative_device", arg);
			return reply.ToObjects<Models.VerifyTentativeDeviceResponse>(this.Converter);
		}

		public async Task<(UserKey ReturnArg0, Timestamp ReturnArg1)> PrepareDelegation(UserNumber arg0, FrontendHostname arg1, SessionKey arg2, OptionalValue<ulong> maxTimeToLive)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter), CandidTypedValue.FromObject(maxTimeToLive, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "prepare_delegation", arg);
			return reply.ToObjects<UserKey, Timestamp>(this.Converter);
		}

		public async Task<Models.GetDelegationResponse> GetDelegation(UserNumber arg0, FrontendHostname arg1, SessionKey arg2, Timestamp arg3)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter), CandidTypedValue.FromObject(arg3, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_delegation", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.GetDelegationResponse>(this.Converter);
		}

		public async Task<Models.HttpResponse> HttpRequest(Models.HttpRequest request)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(request, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "http_request", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<Models.HttpResponse>(this.Converter);
		}

		public async Task<Models.HttpResponse> HttpRequestUpdate(Models.HttpRequest request)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(request, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "http_request_update", arg);
			return reply.ToObjects<Models.HttpResponse>(this.Converter);
		}

		public async Task<Models.DeployArchiveResult> DeployArchive(List<byte> wasm)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(wasm, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "deploy_archive", arg);
			return reply.ToObjects<Models.DeployArchiveResult>(this.Converter);
		}

		public async Task<List<Models.BufferedArchiveEntry>> FetchEntries()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "fetch_entries", arg);
			return reply.ToObjects<List<Models.BufferedArchiveEntry>>(this.Converter);
		}

		public async Task AcknowledgeEntries(ulong sequenceNumber)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(sequenceNumber, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "acknowledge_entries", arg);
		}

		public async Task PruneEventsIfNecessary()
		{
			CandidArg arg = CandidArg.FromCandid();
			await this.Agent.CallAsync(this.CanisterId, "prune_events_if_necessary", arg);
		}

		public async Task InjectPruneEvent(Timestamp timestamp)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(timestamp, this.Converter));
			await this.Agent.CallAsync(this.CanisterId, "inject_prune_event", arg);
		}

		public async Task<InternetIdentityApiClient.CaptchaCreateReturnArg0> CaptchaCreate()
		{
			CandidArg arg = CandidArg.FromCandid();
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "captcha_create", arg);
			return reply.ToObjects<InternetIdentityApiClient.CaptchaCreateReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.IdentityRegisterReturnArg0> IdentityRegister(Models.AuthnMethodData arg0, CaptchaResult arg1, OptionalValue<Principal> arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "identity_register", arg);
			return reply.ToObjects<InternetIdentityApiClient.IdentityRegisterReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.IdentityAuthnInfoReturnArg0> IdentityAuthnInfo(IdentityNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "identity_authn_info", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<InternetIdentityApiClient.IdentityAuthnInfoReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.IdentityInfoReturnArg0> IdentityInfo(IdentityNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "identity_info", arg);
			return reply.ToObjects<InternetIdentityApiClient.IdentityInfoReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0> IdentityMetadataReplace(IdentityNumber arg0, Models.MetadataMapV2 arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "identity_metadata_replace", arg);
			return reply.ToObjects<InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodAddReturnArg0> AuthnMethodAdd(IdentityNumber arg0, Models.AuthnMethodData arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_add", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodAddReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodReplaceReturnArg0> AuthnMethodReplace(IdentityNumber arg0, PublicKey arg1, Models.AuthnMethodData arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_replace", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodReplaceReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0> AuthnMethodMetadataReplace(IdentityNumber arg0, PublicKey arg1, Models.MetadataMapV2 arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_metadata_replace", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0> AuthnMethodSecuritySettingsReplace(IdentityNumber arg0, PublicKey arg1, Models.AuthnMethodSecuritySettings arg2)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter), CandidTypedValue.FromObject(arg2, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_security_settings_replace", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodRemoveReturnArg0> AuthnMethodRemove(IdentityNumber arg0, PublicKey arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_remove", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodRemoveReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0> AuthnMethodRegistrationModeEnter(IdentityNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_registration_mode_enter", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodRegistrationModeExitReturnArg0> AuthnMethodRegistrationModeExit(IdentityNumber arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_registration_mode_exit", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodRegistrationModeExitReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodRegisterReturnArg0> AuthnMethodRegister(IdentityNumber arg0, Models.AuthnMethodData arg1)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(arg1, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_register", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodRegisterReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.AuthnMethodConfirmReturnArg0> AuthnMethodConfirm(IdentityNumber arg0, string confirmationCode)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter), CandidTypedValue.FromObject(confirmationCode, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "authn_method_confirm", arg);
			return reply.ToObjects<InternetIdentityApiClient.AuthnMethodConfirmReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.PrepareIdAliasReturnArg0> PrepareIdAlias(Models.PrepareIdAliasRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			CandidArg reply = await this.Agent.CallAsync(this.CanisterId, "prepare_id_alias", arg);
			return reply.ToObjects<InternetIdentityApiClient.PrepareIdAliasReturnArg0>(this.Converter);
		}

		public async Task<InternetIdentityApiClient.GetIdAliasReturnArg0> GetIdAlias(Models.GetIdAliasRequest arg0)
		{
			CandidArg arg = CandidArg.FromCandid(CandidTypedValue.FromObject(arg0, this.Converter));
			QueryResponse response = await this.Agent.QueryAsync(this.CanisterId, "get_id_alias", arg);
			CandidArg reply = response.ThrowOrGetReply();
			return reply.ToObjects<InternetIdentityApiClient.GetIdAliasReturnArg0>(this.Converter);
		}

		[Variant]
		public class CaptchaCreateReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.CaptchaCreateReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public CaptchaCreateReturnArg0(InternetIdentityApiClient.CaptchaCreateReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected CaptchaCreateReturnArg0()
			{
			}

			public static InternetIdentityApiClient.CaptchaCreateReturnArg0 Ok(Models.Challenge info)
			{
				return new InternetIdentityApiClient.CaptchaCreateReturnArg0(InternetIdentityApiClient.CaptchaCreateReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.CaptchaCreateReturnArg0 Err()
			{
				return new InternetIdentityApiClient.CaptchaCreateReturnArg0(InternetIdentityApiClient.CaptchaCreateReturnArg0Tag.Err, null);
			}

			public Models.Challenge AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.CaptchaCreateReturnArg0Tag.Ok);
				return (Models.Challenge)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.CaptchaCreateReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum CaptchaCreateReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class IdentityRegisterReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.IdentityRegisterReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public IdentityRegisterReturnArg0(InternetIdentityApiClient.IdentityRegisterReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected IdentityRegisterReturnArg0()
			{
			}

			public static InternetIdentityApiClient.IdentityRegisterReturnArg0 Ok(IdentityNumber info)
			{
				return new InternetIdentityApiClient.IdentityRegisterReturnArg0(InternetIdentityApiClient.IdentityRegisterReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.IdentityRegisterReturnArg0 Err(Models.IdentityRegisterError info)
			{
				return new InternetIdentityApiClient.IdentityRegisterReturnArg0(InternetIdentityApiClient.IdentityRegisterReturnArg0Tag.Err, info);
			}

			public IdentityNumber AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.IdentityRegisterReturnArg0Tag.Ok);
				return (IdentityNumber)this.Value!;
			}

			public Models.IdentityRegisterError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.IdentityRegisterReturnArg0Tag.Err);
				return (Models.IdentityRegisterError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.IdentityRegisterReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum IdentityRegisterReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class IdentityAuthnInfoReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.IdentityAuthnInfoReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public IdentityAuthnInfoReturnArg0(InternetIdentityApiClient.IdentityAuthnInfoReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected IdentityAuthnInfoReturnArg0()
			{
			}

			public static InternetIdentityApiClient.IdentityAuthnInfoReturnArg0 Ok(Models.IdentityAuthnInfo info)
			{
				return new InternetIdentityApiClient.IdentityAuthnInfoReturnArg0(InternetIdentityApiClient.IdentityAuthnInfoReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.IdentityAuthnInfoReturnArg0 Err()
			{
				return new InternetIdentityApiClient.IdentityAuthnInfoReturnArg0(InternetIdentityApiClient.IdentityAuthnInfoReturnArg0Tag.Err, null);
			}

			public Models.IdentityAuthnInfo AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.IdentityAuthnInfoReturnArg0Tag.Ok);
				return (Models.IdentityAuthnInfo)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.IdentityAuthnInfoReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum IdentityAuthnInfoReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class IdentityInfoReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.IdentityInfoReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public IdentityInfoReturnArg0(InternetIdentityApiClient.IdentityInfoReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected IdentityInfoReturnArg0()
			{
			}

			public static InternetIdentityApiClient.IdentityInfoReturnArg0 Ok(Models.IdentityInfo info)
			{
				return new InternetIdentityApiClient.IdentityInfoReturnArg0(InternetIdentityApiClient.IdentityInfoReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.IdentityInfoReturnArg0 Err(Models.IdentityInfoError info)
			{
				return new InternetIdentityApiClient.IdentityInfoReturnArg0(InternetIdentityApiClient.IdentityInfoReturnArg0Tag.Err, info);
			}

			public Models.IdentityInfo AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.IdentityInfoReturnArg0Tag.Ok);
				return (Models.IdentityInfo)this.Value!;
			}

			public Models.IdentityInfoError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.IdentityInfoReturnArg0Tag.Err);
				return (Models.IdentityInfoError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.IdentityInfoReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum IdentityInfoReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class IdentityMetadataReplaceReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public IdentityMetadataReplaceReturnArg0(InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected IdentityMetadataReplaceReturnArg0()
			{
			}

			public static InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0 Ok()
			{
				return new InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0(InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0Tag.Ok, null);
			}

			public static InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0 Err(Models.IdentityMetadataReplaceError info)
			{
				return new InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0(InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0Tag.Err, info);
			}

			public Models.IdentityMetadataReplaceError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0Tag.Err);
				return (Models.IdentityMetadataReplaceError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.IdentityMetadataReplaceReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum IdentityMetadataReplaceReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodAddReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodAddReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodAddReturnArg0(InternetIdentityApiClient.AuthnMethodAddReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodAddReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodAddReturnArg0 Ok()
			{
				return new InternetIdentityApiClient.AuthnMethodAddReturnArg0(InternetIdentityApiClient.AuthnMethodAddReturnArg0Tag.Ok, null);
			}

			public static InternetIdentityApiClient.AuthnMethodAddReturnArg0 Err(Models.AuthnMethodAddError info)
			{
				return new InternetIdentityApiClient.AuthnMethodAddReturnArg0(InternetIdentityApiClient.AuthnMethodAddReturnArg0Tag.Err, info);
			}

			public Models.AuthnMethodAddError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodAddReturnArg0Tag.Err);
				return (Models.AuthnMethodAddError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodAddReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum AuthnMethodAddReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodReplaceReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodReplaceReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodReplaceReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodReplaceReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodReplaceReturnArg0 Ok()
			{
				return new InternetIdentityApiClient.AuthnMethodReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodReplaceReturnArg0Tag.Ok, null);
			}

			public static InternetIdentityApiClient.AuthnMethodReplaceReturnArg0 Err(Models.AuthnMethodReplaceError info)
			{
				return new InternetIdentityApiClient.AuthnMethodReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodReplaceReturnArg0Tag.Err, info);
			}

			public Models.AuthnMethodReplaceError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodReplaceReturnArg0Tag.Err);
				return (Models.AuthnMethodReplaceError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodReplaceReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum AuthnMethodReplaceReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodMetadataReplaceReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodMetadataReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodMetadataReplaceReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0 Ok()
			{
				return new InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0Tag.Ok, null);
			}

			public static InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0 Err(Models.AuthnMethodMetadataReplaceError info)
			{
				return new InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0Tag.Err, info);
			}

			public Models.AuthnMethodMetadataReplaceError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0Tag.Err);
				return (Models.AuthnMethodMetadataReplaceError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodMetadataReplaceReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum AuthnMethodMetadataReplaceReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodSecuritySettingsReplaceReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodSecuritySettingsReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodSecuritySettingsReplaceReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0 Ok()
			{
				return new InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0Tag.Ok, null);
			}

			public static InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0 Err(Models.AuthnMethodSecuritySettingsReplaceError info)
			{
				return new InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0(InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0Tag.Err, info);
			}

			public Models.AuthnMethodSecuritySettingsReplaceError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0Tag.Err);
				return (Models.AuthnMethodSecuritySettingsReplaceError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodSecuritySettingsReplaceReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum AuthnMethodSecuritySettingsReplaceReturnArg0Tag
		{
			Ok,
			Err
		}

		public enum AuthnMethodRemoveReturnArg0
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodRegistrationModeEnterReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodRegistrationModeEnterReturnArg0(InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodRegistrationModeEnterReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0 Ok(InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0.OkInfo info)
			{
				return new InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0(InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0 Err()
			{
				return new InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0(InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0Tag.Err, null);
			}

			public InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0.OkInfo AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0Tag.Ok);
				return (InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0.OkInfo)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodRegistrationModeEnterReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}

			public class OkInfo
			{
				[CandidName("expiration")]
				public Timestamp Expiration { get; set; }

				public OkInfo(Timestamp expiration)
				{
					this.Expiration = expiration;
				}

				public OkInfo()
				{
				}
			}
		}

		public enum AuthnMethodRegistrationModeEnterReturnArg0Tag
		{
			Ok,
			Err
		}

		public enum AuthnMethodRegistrationModeExitReturnArg0
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodRegisterReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodRegisterReturnArg0(InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodRegisterReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodRegisterReturnArg0 Ok(Models.AuthnMethodConfirmationCode info)
			{
				return new InternetIdentityApiClient.AuthnMethodRegisterReturnArg0(InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.AuthnMethodRegisterReturnArg0 Err(Models.AuthnMethodRegisterError info)
			{
				return new InternetIdentityApiClient.AuthnMethodRegisterReturnArg0(InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag.Err, info);
			}

			public Models.AuthnMethodConfirmationCode AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag.Ok);
				return (Models.AuthnMethodConfirmationCode)this.Value!;
			}

			public Models.AuthnMethodRegisterError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag.Err);
				return (Models.AuthnMethodRegisterError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodRegisterReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum AuthnMethodRegisterReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class AuthnMethodConfirmReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.AuthnMethodConfirmReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public AuthnMethodConfirmReturnArg0(InternetIdentityApiClient.AuthnMethodConfirmReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected AuthnMethodConfirmReturnArg0()
			{
			}

			public static InternetIdentityApiClient.AuthnMethodConfirmReturnArg0 Ok()
			{
				return new InternetIdentityApiClient.AuthnMethodConfirmReturnArg0(InternetIdentityApiClient.AuthnMethodConfirmReturnArg0Tag.Ok, null);
			}

			public static InternetIdentityApiClient.AuthnMethodConfirmReturnArg0 Err(Models.AuthnMethodConfirmationError info)
			{
				return new InternetIdentityApiClient.AuthnMethodConfirmReturnArg0(InternetIdentityApiClient.AuthnMethodConfirmReturnArg0Tag.Err, info);
			}

			public Models.AuthnMethodConfirmationError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.AuthnMethodConfirmReturnArg0Tag.Err);
				return (Models.AuthnMethodConfirmationError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.AuthnMethodConfirmReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum AuthnMethodConfirmReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class PrepareIdAliasReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public PrepareIdAliasReturnArg0(InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected PrepareIdAliasReturnArg0()
			{
			}

			public static InternetIdentityApiClient.PrepareIdAliasReturnArg0 Ok(Models.PreparedIdAlias info)
			{
				return new InternetIdentityApiClient.PrepareIdAliasReturnArg0(InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.PrepareIdAliasReturnArg0 Err(Models.PrepareIdAliasError info)
			{
				return new InternetIdentityApiClient.PrepareIdAliasReturnArg0(InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag.Err, info);
			}

			public Models.PreparedIdAlias AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag.Ok);
				return (Models.PreparedIdAlias)this.Value!;
			}

			public Models.PrepareIdAliasError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag.Err);
				return (Models.PrepareIdAliasError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.PrepareIdAliasReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum PrepareIdAliasReturnArg0Tag
		{
			Ok,
			Err
		}

		[Variant]
		public class GetIdAliasReturnArg0
		{
			[VariantTagProperty]
			public InternetIdentityApiClient.GetIdAliasReturnArg0Tag Tag { get; set; }

			[VariantValueProperty]
			public object? Value { get; set; }

			public GetIdAliasReturnArg0(InternetIdentityApiClient.GetIdAliasReturnArg0Tag tag, object? value)
			{
				this.Tag = tag;
				this.Value = value;
			}

			protected GetIdAliasReturnArg0()
			{
			}

			public static InternetIdentityApiClient.GetIdAliasReturnArg0 Ok(Models.IdAliasCredentials info)
			{
				return new InternetIdentityApiClient.GetIdAliasReturnArg0(InternetIdentityApiClient.GetIdAliasReturnArg0Tag.Ok, info);
			}

			public static InternetIdentityApiClient.GetIdAliasReturnArg0 Err(Models.GetIdAliasError info)
			{
				return new InternetIdentityApiClient.GetIdAliasReturnArg0(InternetIdentityApiClient.GetIdAliasReturnArg0Tag.Err, info);
			}

			public Models.IdAliasCredentials AsOk()
			{
				this.ValidateTag(InternetIdentityApiClient.GetIdAliasReturnArg0Tag.Ok);
				return (Models.IdAliasCredentials)this.Value!;
			}

			public Models.GetIdAliasError AsErr()
			{
				this.ValidateTag(InternetIdentityApiClient.GetIdAliasReturnArg0Tag.Err);
				return (Models.GetIdAliasError)this.Value!;
			}

			private void ValidateTag(InternetIdentityApiClient.GetIdAliasReturnArg0Tag tag)
			{
				if (!this.Tag.Equals(tag))
				{
					throw new InvalidOperationException($"Cannot cast '{this.Tag}' to type '{tag}'");
				}
			}
		}

		public enum GetIdAliasReturnArg0Tag
		{
			Ok,
			Err
		}
	}
}