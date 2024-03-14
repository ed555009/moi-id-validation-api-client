using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MOI.Id.Validation.Api.Client.Configs;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Models.Requests;

namespace MOI.Id.Validation.Api.Client.Services;

public class JwtService : IJwtService
{
	private readonly ILogger<JwtService> _logger;
	private readonly JwtConfig _jwtConfig;
	private readonly MOIIdValidationApiConfig _mOIIdVerificationApiConfig;

	public JwtService(ILogger<JwtService> logger, JwtConfig jwtConfig, MOIIdValidationApiConfig mOIIdValidationApiConfig)
	{
		_logger = logger;
		_jwtConfig = jwtConfig;
		_mOIIdVerificationApiConfig = mOIIdValidationApiConfig;
	}

	public async Task<string> BuildAsync(ConditionMapModel conditionMapModel)
	{
		using RSA rsa = RSA.Create();
		rsa.ImportRSAPrivateKey(GetRSAPrivateKey(), out _);

		JwtSecurityToken jwtSecurityToken = new(
			claims: await BuildClaims(conditionMapModel),
			signingCredentials: new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
			{
				CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
			}
		);

		var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

		_logger.LogDebug("JWT Token: {Token}", token);

		return token;
	}

	byte[] GetRSAPrivateKey() =>
		Convert.FromBase64String(_mOIIdVerificationApiConfig.RSAPrivateKey
			.Replace("-----BEGIN RSA PRIVATE KEY-----", string.Empty)
			.Replace("-----END RSA PRIVATE KEY-----", string.Empty)
			.Replace("\n", string.Empty)
			.Replace("\r", string.Empty));

	async Task<IEnumerable<Claim>> BuildClaims(ConditionMapModel conditionMapModel)
	{
		var now = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(8));

		return new List<Claim>
		{
			new("orgId", _jwtConfig.OrganizationId),
			new("apId", _jwtConfig.ApplicationId),
			new("userId", JwtConfig.UserId),
			new("jobId", JwtConfig.JobId),
			new("opType", JwtConfig.OpType),
			new("conditionMap", JsonSerializer.Serialize(conditionMapModel)),
			new(JwtRegisteredClaimNames.Iss, _jwtConfig.Issuer),
			new(JwtRegisteredClaimNames.Aud, now.ToString("yyyy/MM/dd HH:mm:ss.fff")),
			new(JwtRegisteredClaimNames.Iat, now.AddSeconds(-150).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
			new(JwtRegisteredClaimNames.Exp, now.AddSeconds(150).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
			new(JwtRegisteredClaimNames.Sub, JwtConfig.Subject),
			new(JwtRegisteredClaimNames.Jti, await JwtConfig.JtiGenerator())
		};
	}
}
