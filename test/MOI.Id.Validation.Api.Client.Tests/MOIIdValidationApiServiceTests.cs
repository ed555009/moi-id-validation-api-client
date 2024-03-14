using System.Net;
using Microsoft.Extensions.Logging;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Models.Responses;
using MOI.Id.Validation.Api.Client.Services;
using Moq;
using Xunit.Abstractions;

namespace MOI.Id.Validation.Api.Client.Tests;

public class MOIIdValidationApiServiceTests : BaseServiceTests
{
	private readonly Mock<IMOIIdValidationApi> _moiIdValidationApiMock;
	private readonly IMOIIdValidationApiService _moiIdValidationApiService;
	private readonly IJwtService _jwtService;

	public MOIIdValidationApiServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_jwtService = new JwtService(Mock.Of<ILogger<JwtService>>(), JwtConfig, MOIIdValidationApiConfig);
		_moiIdValidationApiMock = new Mock<IMOIIdValidationApi>();
		_moiIdValidationApiService = new MOIIdValidationApiService(
			Mock.Of<ILogger<MOIIdValidationApiService>>(),
			_moiIdValidationApiMock.Object, _jwtService);
	}

	[Fact]
	public async void ValidateAsync_ShouldSucceed()
	{
		// Given
		_ = _moiIdValidationApiMock
			.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
			.Returns(CreateResponse<CheckIdCardModel>(HttpStatusCode.OK));

		// When
		var result = await _moiIdValidationApiService.ValidateAsync(ConditionMapModel, CancellationToken.None);

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}
