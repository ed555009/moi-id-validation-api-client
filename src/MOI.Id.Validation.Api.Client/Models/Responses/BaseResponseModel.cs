using System.Text.Json.Serialization;
using MOI.Id.Validation.Api.Client.Interfaces;

namespace MOI.Id.Validation.Api.Client.Models.Responses;

public abstract class BaseResponseModel<T> : IBaseResponseModel
{
	/// <summary>
	/// Http狀態碼
	/// </summary>
	public int HttpCode { get; set; }

	/// <summary>
	/// Http狀態訊息
	/// </summary>
	public string? HttpMessage { get; set; }

	/// <summary>
	/// 內政部連結應用系統回應碼
	/// </summary>
	[JsonPropertyName("rdCode")]
	public string? ResponseCode { get; set; }

	/// <summary>
	/// 內政部連結應用系統回應訊息
	/// </summary>
	[JsonPropertyName("rdMessage")]
	public string? ResponseMessage { get; set; }

	/// <summary>
	/// 返回資料
	/// </summary>
	public T? ResponseData { get; set; }
}
