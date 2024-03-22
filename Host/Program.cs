using Host;
using Host.Services;

using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHealthService, HealthService>();

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>(nameof(SampleHealthCheck))
    .ForwardToPrometheus();

builder.Services.UseHttpClientMetrics();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.WithOpenApi();

app.UseHttpsRedirection();

app.UseRouting();

app.UseHttpMetrics();

app.MapMetrics();
app.MapHealthChecks("/healthz");
app.MapWeatherEndpoints("/weatherforecast");

app.Run();

public partial class Program { }
