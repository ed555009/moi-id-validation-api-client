using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOI.Id.Validation.Api.Client.Configs;
using MOI.Id.Validation.Api.Client.Extensions;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Services;
using Xunit.Abstractions;

namespace MOI.Id.Validation.Api.Client.Tests;

public class ServicesExtensionTests : BaseServiceTests
{
	private readonly string _settings;
	private readonly string _nullSettings;

	public ServicesExtensionTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_settings = JsonSerializer.Serialize(new
		{
			MOIId = new
			{
				ValidationApi = new
				{
					MOIIdValidationApiConfig.BaseUrl,
					MOIIdValidationApiConfig.RSAPrivateKey
				},
				Jwt = new
				{
					JwtConfig.OrganizationId,
					JwtConfig.ApplicationId,
					JwtConfig.Issuer
				}
			}
		});

		_nullSettings = JsonSerializer.Serialize(new
		{
			MOIId = new
			{
				ValidationApi = new
				{
				},
				Jwt = new
				{
				}
			}
		});
	}

	[Fact]
	public void AddMOIIdValidationApiClient_ShouldSucceed()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddMOIIdValidationApiClient(services, configuration);

		// Then
		Assert.Contains(services, x => x.ServiceType == typeof(MOIIdValidationApiConfig));
		Assert.Contains(services, x => x.ServiceType == typeof(JwtConfig));

		Assert.Contains(services, x => x.ServiceType == typeof(IMOIIdValidationApi));

		Assert.Contains(services, x => x.ServiceType == typeof(IMOIIdValidationApiService)
								 && x.ImplementationType == typeof(MOIIdValidationApiService));

		Assert.Contains(services, x => x.ServiceType == typeof(IJwtService)
								 && x.ImplementationType == typeof(JwtService));
	}

	[Fact]
	public void AddMOIIdValidationApiClient_WithNullConfig_ShouldThrow()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_nullSettings))).Build();

		// When
		var ex = Assert.Throws<ArgumentNullException>(() =>
			ServicesExtensions.AddMOIIdValidationApiClient(services, configuration));

		// Then
		Assert.NotNull(ex);
	}
}
