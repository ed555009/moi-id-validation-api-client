using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MOI.Id.Validation.Api.Client.Enums;

/// <summary>
/// 行政區域代碼
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IssueSiteType
{/// <summary>
 /// 連江
 /// </summary>
	[EnumMember(Value = "09007")]
	FjLienchiangCounty = 9007,

	/// <summary>
	/// 金門
	/// </summary>
	[EnumMember(Value = "09020")]
	FjKinmenCounty = 9020,

	/// <summary>
	/// 北縣
	/// </summary>
	[EnumMember(Value = "10001")]
	TwTaipeiCounty = 10001,

	/// <summary>
	/// 宜縣
	/// </summary>
	[EnumMember(Value = "10002")]
	TwYilanCounty = 10002,

	/// <summary>
	/// 桃縣
	/// </summary>
	[EnumMember(Value = "10003")]
	TwTaoyuanCounty = 10003,

	/// <summary>
	/// 竹縣
	/// </summary>
	[EnumMember(Value = "10004")]
	TwHsinchuCounty = 10004,

	/// <summary>
	/// 苗縣
	/// </summary>
	[EnumMember(Value = "10005")]
	TwMiaoliCounty = 10005,

	/// <summary>
	/// 中縣
	/// </summary>
	[EnumMember(Value = "10006")]
	TwTaichungCounty = 10006,

	/// <summary>
	/// 彰縣
	/// </summary>
	[EnumMember(Value = "10007")]
	TwChanghuaCounty = 10007,

	/// <summary>
	/// 投縣
	/// </summary>
	[EnumMember(Value = "10008")]
	TwNantouCounty = 10008,

	/// <summary>
	/// 雲縣
	/// </summary>
	[EnumMember(Value = "10009")]
	TwYunlinCounty = 10009,

	/// <summary>
	/// 嘉縣
	/// </summary>
	[EnumMember(Value = "10010")]
	TwChiayiCounty = 10010,

	/// <summary>
	/// 南縣
	/// </summary>
	[EnumMember(Value = "10011")]
	TwTainanCounty = 10011,

	/// <summary>
	/// 高縣
	/// </summary>
	[EnumMember(Value = "10012")]
	TwKaohsiungCounty = 10012,

	/// <summary>
	/// 屏縣
	/// </summary>
	[EnumMember(Value = "10013")]
	TwPingtungCounty = 10013,

	/// <summary>
	/// 東縣
	/// </summary>
	[EnumMember(Value = "10014")]
	TwTaitungCounty = 10014,

	/// <summary>
	/// 花縣
	/// </summary>
	[EnumMember(Value = "10015")]
	TwHualienCounty = 10015,

	/// <summary>
	/// 澎縣
	/// </summary>
	[EnumMember(Value = "10016")]
	TwPenghuCounty = 10016,

	/// <summary>
	/// 基市
	/// </summary>
	[EnumMember(Value = "10017")]
	TwKeelungCity = 10017,

	/// <summary>
	/// 竹市
	/// </summary>
	[EnumMember(Value = "10018")]
	TwHsinchuCity = 10018,

	/// <summary>
	/// 嘉市
	/// </summary>
	[EnumMember(Value = "10020")]
	TwChiayiCity = 10020,

	/// <summary>
	/// 北市
	/// </summary>
	[EnumMember(Value = "63000")]
	TaipeiCity = 63000,

	/// <summary>
	/// 高市
	/// </summary>
	[EnumMember(Value = "64000")]
	KaohsiungCity = 64000,

	/// <summary>
	/// 新北市
	/// </summary>
	[EnumMember(Value = "65000")]
	NewTaipeiCity = 65000,

	/// <summary>
	/// 中市
	/// </summary>
	[EnumMember(Value = "66000")]
	TaichungCity = 66000,

	/// <summary>
	/// 南市
	/// </summary>
	[EnumMember(Value = "67000")]
	TainanCity = 67000,

	/// <summary>
	/// 桃市
	/// </summary>
	[EnumMember(Value = "68000")]
	TaoyuanCity = 68000
}
