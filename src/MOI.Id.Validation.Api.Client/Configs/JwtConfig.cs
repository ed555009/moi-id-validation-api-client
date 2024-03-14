using MOI.Id.Validation.Api.Client.Interfaces;
using Unified;

namespace MOI.Id.Validation.Api.Client.Configs;

public class JwtConfig : IAppConfig
{
	/// <summary>
	/// 營利事業登記證號，8碼
	/// </summary>
	public string OrganizationId { get; set; } = "12345678";

	/// <summary>
	/// 內政部配賦之公司（企業）帳號，最長5碼
	/// </summary>
	public string ApplicationId { get; set; } = "12345";

	/// <summary>
	/// 內政部配賦之iss key
	/// </summary>
	public string Issuer { get; set; } = "Issuer";

	/// <summary>
	/// 能識別公司（企業）內部使用者之帳號，供日誌記錄用，最長12碼（英數）
	/// </summary>
	public static string UserId => new UnifiedId(DateTime.UtcNow.Ticks).ToString()[..12];

	/// <summary>
	/// 內政部配賦之作業代號，固定值
	/// </summary>
	public static string JobId => "V2C201";

	/// <summary>
	/// 固定值
	/// </summary>
	public static string OpType => "RW";

	/// <summary>
	/// 固定值-綠色便民專案
	/// </summary>
	public static string Subject => "綠色便民專案";

	/// <summary>
	/// JWT ID唯一識別碼（建議使用各語言的JWT套件產生）
	/// </summary>
	public static Func<Task<string>> JtiGenerator =>
		() => Task.FromResult(Guid.NewGuid().ToString());
}
