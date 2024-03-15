using System.Net;
using MOI.Id.Validation.Api.Client.Configs;
using MOI.Id.Validation.Api.Client.Enums;
using MOI.Id.Validation.Api.Client.Interfaces;
using MOI.Id.Validation.Api.Client.Models.Requests;
using Refit;
using Xunit.Abstractions;

namespace MOI.Id.Validation.Api.Client.Tests;

public class BaseServiceTests
{
	protected readonly ITestOutputHelper TestOutputHelper;
	protected readonly ConditionMapModel ConditionMapModel;
	protected readonly JwtConfig JwtConfig;
	protected readonly MOIIdValidationApiConfig MOIIdValidationApiConfig;

	public BaseServiceTests(ITestOutputHelper testOutputHelper)
	{
		TestOutputHelper = testOutputHelper;
		ConditionMapModel = new ConditionMapModel
		{
			PersonId = "X123456789",
			IssuedType = IssueType.InitialIssued,
			IssuedDate = "0970102",
			IssuedSite = IssueSiteType.NewTaipeiCity
		};
		JwtConfig = new JwtConfig
		{
			OrganizationId = "12345678",
			ApplicationId = "12345",
			Issuer = "my_iss_key"
		};
		MOIIdValidationApiConfig = new MOIIdValidationApiConfig
		{
			BaseUrl = "http://localhost:5000",
			RSAPrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIIEogIBAAKCAQEAlZnxX8z5xm91tLHocmr+lZ2PBdu0zvawZr5oSPuFk3/TGQlU
fzeWG75+yoZH26oCNHCxddcwxo6i0wJa3ocx5sKPHNmUaK+MP8jH7etjo+Tku1cH
VcuW00M1rX3ReE4ixbWSR9qQpzSjkR4mpxyPIajjreR0RiPqm9VrizBQSv9Ydp29
Ewu0SErXp9IU+Hcqn++2tXpEp09oh/+eKlfaIlFaE3zN/d9gFIxdQBGIuD7kU6ID
2PFE3yb2+tnWncIuviGG60bG9DmYaIvNuqI0OSxuoVZ0MCHbjgzd4yn7FbxVNaIE
avx2gY3kIqueTN8kAMsO2z50ENgxKOKvBT6Z6QIDAQABAoIBAAXk8bKIGs6bj/mF
dEv5yjvD4Ew8oARINPgUstAuqiXUc1FOYaK84nBdEkAm3UhFi7Oxkv8Px6SzHwLj
BLM1hBz8TR43tmtk1fOiFLqGO+qhDKAS/uooTNzYY5Iz3bUjQvx45Ha/S6ltigT1
jqlRQenIw+ZolL+PZQwscwHMxAUduLDAGvJ6xlUX02StwU6+DS/wm0MzsFGH1/om
uGNItAQsvrz2d2y6VOyRjUHg1YVazklR2H6UyzShQKehJz1WgfCWLCZQWX5WmxSy
SqWw0grfOlKnlU6SP/byiYCuNEnH+Gq5linFiSvX+Tu/gwsXtjsu2ZEqkMh3cD8M
y+HaA8ECgYEAyG2NyuNb+ZckMbp79P2X3Dnzbtud9lr5gi7ppHJ1GzI+UMHBMwhM
COkUIF1goMYH3Zx4PckLM5ebcv24YfaQFneyO77SDJIC2sZ2VEJJ2HhiJ+TEnrmM
8LVNYGDUbsOrU2V+xav/cUzYRXazCpT8ycYoFW/0my88ymWjWoHLMfkCgYEAvxSy
2VwDhcN1v3jdCplDz0iC5RNRY9b4C4bNtsOodDJ5KSw0ON9b44f0YVwp1e7pL6YD
3taVNKXEQy2t88UcpxiBKk9BNceb+OgGPRx17dXp3dtDZnFBZ1DbmhLHh+0/NDUH
xwe41UhsnGcPUVDu9f2oEmJ33tObKl6/JZaco3ECgYB1jLNdrC0UXI2w0MPEszru
wdpBSXMCuuadcLA9b5e5RKWBrbGHIbWegDz6oml6wcp5MjzfV9tG/gMA1UffxMFL
PBZ/rfH5x2T/NOjPkDVJTYmcBjM/OGot/teL0B6nfAEun1dTzgW6SKyLSQvHCAye
tqZptEjM/05zEltVSMyI2QKBgB6RPRswcQ/Q+OEsgI/VfNeIDgh/UqHaHcwaQIZg
Pm54NJG1lJUUhiqb8SgyCi9DDOKmeDAJu8y0R/VHNXCts6u3a9JM422rBPSIiZb1
Gph1g/gNv3Z/36qbcMXxAyJnfZjoctoQDi1wbI+InRaxD8kiTuTCA9MNnuDkT0fA
FEbBAoGAftWZcnwJ7X3cB/EgBo71g0fzOpz9XM9sxlbW8mKaVvlhbNHk/+Eqfycj
QdQABDosYXT/nNQ2GSxzZtjCa57kj/YLAwW3uQaSVYA6v9GO3a6yiAXjimDNr1Eu
uwvm6I8s8TQzSwrK3ToKF7JcaIoLMhXhHLEdPl7xnNDnrjUdJVI=
-----END RSA PRIVATE KEY-----"
		};
	}

	protected static Task<ApiResponse<T>> CreateResponse<T>(HttpStatusCode statusCode) where T : IBaseResponseModel =>
		Task.FromResult(new ApiResponse<T>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));

	protected static Task<ApiResponse<object?>> CreateEmptyResponse(HttpStatusCode statusCode) =>
		Task.FromResult(new ApiResponse<object?>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));

	protected static Task<ApiResponse<string>> CreateStringResponse(HttpStatusCode statusCode) =>
		Task.FromResult(new ApiResponse<string>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));
}
