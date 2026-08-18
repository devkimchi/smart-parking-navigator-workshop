using Aspire.Hosting.ApplicationModel;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<ParameterResource> googleMapsApiKey = builder.AddParameterFromConfiguration(
    "google-maps-api-key",
    "GoogleMaps:ApiKey",
    secret: true);
IResourceBuilder<ParameterResource> dataGovSgApiKey = builder.AddParameterFromConfiguration(
    "data-gov-sg-api-key",
    "DataGovSg:ApiKey",
    secret: true);

IResourceBuilder<ProjectResource> api = builder
    .AddProject<Projects.CarparkAvailability_ApiApp>("apiapp")
    .WithEnvironment("DataGovSg__ApiKey", dataGovSgApiKey);

builder
    .AddProject<Projects.CarparkAvailability_WebApp>("webapp")
    .WithEnvironment("GoogleMaps__ApiKey", googleMapsApiKey)
    .WithReference(api)
    .WaitFor(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();
