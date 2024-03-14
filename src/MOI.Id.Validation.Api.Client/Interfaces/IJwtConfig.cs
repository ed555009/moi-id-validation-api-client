namespace MOI.Id.Validation.Api.Client.Interfaces;

public interface IJwtConfig
{

	/// <summary>
	/// 營利事業登記證號，8碼
	/// </summary>
	string OrganizationId { get; set; }

	/// <summary>
	/// 內政部配賦之公司（企業）帳號，最長5碼
	/// </summary>
	string ApplicationId { get; set; }

	/// <summary>
	/// 內政部配賦之iss key
	/// </summary>
	string Issuer { get; set; }

	/// <summary>
	/// 能識別公司（企業）內部使用者之帳號，供日誌記錄用，最長12碼（英數）
	/// </summary>
	string UserId { get; }

	/// <summary>
	/// 內政部配賦之作業代號，固定值
	/// </summary>
	string JobId { get; }

	/// <summary>
	/// 固定值
	/// </summary>
	string OpType { get; }

	/// <summary>
	/// 固定值-綠色便民專案
	/// </summary>
	string Subject { get; }

	/// <summary>
	/// 送出查詢之日期時間
	/// </summary>
	string Audience { get; }

	/// <summary>
	/// Token有效起始時間，timestamp格式（建議發送時間-180秒）
	/// </summary>
	long IssuedAt { get; }

	/// <summary>
	/// Token有效迄止時間，timestamp格式（建議發送時間+180秒）
	/// </summary>
	long ExpiredAt { get; }
}
