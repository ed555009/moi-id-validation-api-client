using Microsoft.Extensions.Logging;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Services;
using Moq;
using Xunit.Abstractions;

namespace MOI.Id.Validation.Api.Client.Tests;

public class JwtServiceTests : BaseServiceTests
{
	private readonly IJwtService _jwtService;

	public JwtServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) =>
		_jwtService = new JwtService(Mock.Of<ILogger<JwtService>>(), JwtConfig, MOIIdValidationApiConfig);

	[Fact]
	public async Task BuildAsync_ShouldSucceed()
	{
		// Given

		// When
		var result = await _jwtService.BuildAsync(ConditionMapModel);

		// Then
		Assert.NotNull(result);
		Assert.StartsWith("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9", result);

		TestOutputHelper.WriteLine(result);
	}
}
