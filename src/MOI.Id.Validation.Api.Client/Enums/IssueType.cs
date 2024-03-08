using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MOI.Id.Validation.Api.Client.Enums;

/// <summary>
/// 領補換類別
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IssueType
{
	/// <summary>
	/// 未發
	/// </summary>
	[EnumMember(Value = "0")]
	NotIssued = 0,

	/// <summary>
	/// 初發
	/// </summary>
	[EnumMember(Value = "1")]
	InitialIssued = 1,

	/// <summary>
	/// 補發
	/// </summary>
	[EnumMember(Value = "2")]
	Reissued = 2,

	/// <summary>
	/// 換發
	/// </summary>
	[EnumMember(Value = "3")]
	Replaced = 3
}
