using MOI.Id.Validation.Api.Client.Models.Requests;
using MOI.Id.Validation.Api.Client.Models.Responses;
using Refit;

namespace MOI.Id.Validation.Api.Client.Interfaces;

/// <summary>
/// 驗證身分證API服務
/// </summary>
public interface IMOIIdValidationApiService
{
	/// <summary>
	/// 驗證
	/// </summary>
	Task<ApiResponse<CheckIdCardModel>> ValidateAsync(
		ConditionMapModel conditionMapModel,
		CancellationToken cancellationToken = default);
}
