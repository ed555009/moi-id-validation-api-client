using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MOI.Id.Validation.Api.Client.Enums;
using MOI.Id.Validation.Api.Client.Interfaces;

namespace MOI.Id.Validation.Api.Client.Models.Requests;

public class ConditionMapModel : IBaseRequestModel
{
	/// <summary>
	/// 國民身分證統一編號，10碼，第1碼為大寫英文字母，第2碼為1或2，第3-10碼為數字
	/// </summary>
	[Required, RegularExpression(@"^[A-Z][1|2]\d{8}$")]
	[JsonPropertyName("personId")]
	public string? PersonId { get; set; }

	/// <summary>
	/// 領補換類別代碼
	/// </summary>
	[Required]
	[JsonPropertyName("applyCode")]
	public IssueType? IssuedType { get; set; }

	/// <summary>
	/// 發證日期，民國格式7碼
	/// </summary>
	[Required, RegularExpression(@"^[0-1]\d{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])$")]
	[JsonPropertyName("applyYyymmdd")]
	public string? IssuedDate { get; set; }

	/// <summary>
	/// 發證地點行政區域代碼，5碼
	/// </summary>
	[Required]
	[JsonPropertyName("issueSiteId")]
	public IssueSiteType? IssuedSite { get; set; }
}
