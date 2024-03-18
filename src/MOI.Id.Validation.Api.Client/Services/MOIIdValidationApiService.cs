using Microsoft.Extensions.Logging;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Models.Requests;
using MOI.Id.Validation.Api.Client.Models.Responses;
using Refit;

namespace MOI.Id.Validation.Api.Client.Services;

public class MOIIdValidationApiService : IMOIIdValidationApiService
{
	private readonly ILogger<MOIIdValidationApiService> _logger;
	private readonly IMOIIdValidationApi _mOIIdValidationApi;
	private readonly IJwtService _jwtService;

	public MOIIdValidationApiService(
		ILogger<MOIIdValidationApiService> logger,
		IMOIIdValidationApi mOIIdValidationApi,
		IJwtService jwtService)
	{
		_logger = logger;
		_mOIIdValidationApi = mOIIdValidationApi;
		_jwtService = jwtService;
	}

	public async Task<ApiResponse<CheckIdCardModel>> ValidateAsync(
		ConditionMapModel conditionMapModel,
		CancellationToken cancellationToken = default)
	{
		_logger.LogDebug("ValidateAsync ConditionMapModel: {@ConditionMapModel}", conditionMapModel);

		var result = await _mOIIdValidationApi.GetAsync(
			await _jwtService.BuildAsync(conditionMapModel),
			cancellationToken);

		_logger.LogDebug("ValidateAsync StatusCode: {StatusCode}, IsSuccess: {IsSuccess}",
			result.StatusCode,
			result.IsSuccessStatusCode);
		_logger.LogDebug("ValidateAsync Result content: {@ResultContent}", result.Content);

		return result;
	}
}
