# MOI.Id.Validation.Api.Client

[![GitHub](https://img.shields.io/github/license/ed555009/moi-id-validation-api-client)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/moi-id-validation-api-client?branchName=main)
[![Nuget](https://img.shields.io/nuget/v/MOI.Id.Validation.Api.Client)](https://www.nuget.org/packages/MOI.Id.Validation.Api.Client)

![Coverage](https://sonarcloud.io/api/project_badges/measure?project=moi-id-validation-api-client&metric=coverage)
![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=moi-id-validation-api-client&metric=alert_status)
![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=moi-id-validation-api-client&metric=reliability_rating)
![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=moi-id-validation-api-client&metric=security_rating)
![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=moi-id-validation-api-client&metric=vulnerabilities)


## Installation

```bash
dotnet add package MOI.Id.Validation.Api.Client
```

## Configuration

### Appsettings.json

```json
{
	"MOIId": {
		"ValidationApi": {
			"BaseUrl": "https://rwa.moi.gov.tw:1443",
			"RSAPrivateKey": "YOUR_RSA_PRIVATE_KEY"
		},
		"Jwt": {
			"OrganizationId": "YOUR_ORGANIZATION_ID",
			"ApplicationId": "YOUR_APPLICATION_ID",
			"Issuer": "YOUR_ISS_KEY",
		}
	}
}
```

### Add services

```csharp
using MOI.Id.Validation.Api.Client.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// this injects as SINGLETON
	services.AddMOIIdValidationApiClient(configuration);

	// you can also inject as SCOPED or TRANSIENT by specifying the ServiceLifetime
	services.AddMOIIdValidationApiClient(configuration, ServiceLifetime.Scoped);
}
```

# Reference

- [內政部戶政司國民身分證領補換資料查驗作業API介接服務](https://www.ris.gov.tw/app/portal/861)
