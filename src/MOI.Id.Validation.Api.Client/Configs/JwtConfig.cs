using MOI.Id.Validation.Api.Client.Interfaces;
using Unified;

namespace MOI.Id.Validation.Api.Client.Configs;

public class JwtConfig : IJwtConfig, IAppConfig
{
	private readonly DateTimeOffset _now = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(8));

	public string OrganizationId { get; set; } = "12345678";

	public string ApplicationId { get; set; } = "12345";

	public string Issuer { get; set; } = "Issuer";

	public string UserId => new UnifiedId(DateTime.UtcNow.Ticks).ToString()[..12];

	public string JobId => "V2C201";

	public string OpType => "RW";

	public string Subject => "綠色便民專案";

	public string Audience => _now.ToString("yyyy/MM/dd HH:mm:ss.fff");

	public long IssuedAt => _now.AddSeconds(-150).ToUnixTimeSeconds();

	public long ExpiredAt => _now.AddSeconds(150).ToUnixTimeSeconds();

	/// <summary>
	/// JWT ID唯一識別碼（建議使用各語言的JWT套件產生）
	/// </summary>
	public static Func<Task<string>> JtiGenerator =>
		() => Task.FromResult(Guid.NewGuid().ToString());
}
