namespace Host;

using Host.Services;

using Microsoft.Extensions.Diagnostics.HealthChecks;

public sealed class SampleHealthCheck(IHealthService healthService) : IHealthCheck
{
    private readonly IHealthService _healthService = healthService;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        bool isApiHealthy = await _healthService.IsHealthyAsync();

        if (isApiHealthy)
        {
            return await Task.FromResult(HealthCheckResult.Healthy());
        }

        return await Task.FromResult(HealthCheckResult.Unhealthy());
    }
}