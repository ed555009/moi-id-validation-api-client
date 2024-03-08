using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Models.Requests;
using MOI.Id.Validation.Api.Client.Models.Responses;
using Refit;

namespace MOI.Id.Validation.Api.Client.Services;

public class MOIIdValidationApiService : IMOIIdValidationApiService
{
	private readonly IMOIIdValidationApi _mOIIdValidationApi;
	private readonly IJwtService _jwtService;

	public MOIIdValidationApiService(IMOIIdValidationApi mOIIdValidationApi, IJwtService jwtService)
	{
		_mOIIdValidationApi = mOIIdValidationApi;
		_jwtService = jwtService;
	}

	public async Task<ApiResponse<CheckIdCardModel>> ValidateAsync(
		ConditionMapModel conditionMapModel,
		CancellationToken cancellationToken = default) =>
			await _mOIIdValidationApi.GetAsync(await _jwtService.BuildAsync(conditionMapModel), cancellationToken);
}
