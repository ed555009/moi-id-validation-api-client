using MOI.Id.Validation.Api.Client.Models.Responses;
using Refit;

namespace MOI.Id.Validation.Api.Client.Interfaces;

[Headers("sris-consumerAdminId: 00000000", "Content-Type: application/json")]
public interface IMOIIdValidationApi
{
	[Get("/")]
	Task<ApiResponse<CheckIdCardModel>> GetAsync(
		[Authorize("Bearer")] string token,
		CancellationToken cancellationToken = default);
}
