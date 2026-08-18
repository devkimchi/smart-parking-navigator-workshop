WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api", () => Results.Ok(new
{
    name = "Smart Parking Navigator API",
    status = "Starter scaffold"
}));

app.MapDefaultEndpoints();

app.Run();
