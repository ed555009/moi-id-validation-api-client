using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOI.Id.Validation.Api.Client.Configs;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Services;
using Refit;

namespace MOI.Id.Validation.Api.Client.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddMOIIdValidationApiClient(
		this IServiceCollection services,
		IConfiguration configuration,
		ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
	{
		var jwtConfig = GetJwtConfig(configuration);
		var moiIdValidationApiConfig = GetMOIIdValidationApiConfig(configuration);
		var refitSettings = GetRefitSettings();

		_ = services
			.AddTransient<IJwtConfig>(_ => jwtConfig)
			.AddSingleton(moiIdValidationApiConfig)
			.AddRefitClient<IMOIIdValidationApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{moiIdValidationApiConfig.BaseUrl}/integration/rwv2c2"));

		switch (serviceLifetime)
		{
			case ServiceLifetime.Scoped:
				_ = services
					.AddScoped<IJwtService, JwtService>()
					.AddScoped<IMOIIdValidationApiService, MOIIdValidationApiService>();
				break;
			case ServiceLifetime.Transient:
				_ = services
					.AddTransient<IJwtService, JwtService>()
					.AddTransient<IMOIIdValidationApiService, MOIIdValidationApiService>();
				break;
			default:
				_ = services
					.AddSingleton<IJwtService, JwtService>()
					.AddSingleton<IMOIIdValidationApiService, MOIIdValidationApiService>();
				break;
		}

		return services;
	}

	static JwtConfig GetJwtConfig(IConfiguration configuration) =>
		configuration
			.GetSection("MOIId")
			.GetSection("Jwt")
			.Get<JwtConfig>()
				?? throw new ArgumentNullException(nameof(configuration), "Could not find Jwt config");

	static MOIIdValidationApiConfig GetMOIIdValidationApiConfig(IConfiguration configuration) =>
		configuration
			.GetSection("MOIId")
			.GetSection("ValidationApi")
			.Get<MOIIdValidationApiConfig>()
				?? throw new ArgumentNullException(nameof(configuration), "Could not find Validation Api config");

	static RefitSettings GetRefitSettings() =>
		new()
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				Converters =
				{
					new JsonStringEnumConverter()
				},
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				PropertyNameCaseInsensitive = true
			})
		};
}
