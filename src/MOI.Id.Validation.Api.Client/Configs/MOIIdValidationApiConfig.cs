using MOI.Id.Validation.Api.Client.Interfaces;

namespace MOI.Id.Validation.Api.Client.Configs;

public class MOIIdValidationApiConfig : IAppConfig
{
	public string BaseUrl { get; set; } = "https://rwa.moi.gov.tw:1443";

	/// <summary>
	/// RSA-2048私鑰
	/// </summary>
	public string RSAPrivateKey { get; set; } = "PrivateKey";
}
