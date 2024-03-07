using MOI.Id.Validation.Api.Client.Models.Requests;

namespace MOI.Id.Validation.Api.Client.Interfaces;

public interface IJwtService
{
	Task<string> BuildAsync(ConditionMapModel conditionMapModel);
}
