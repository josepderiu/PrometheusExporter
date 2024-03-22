namespace Host.IntegrationTests;

using Host.Services;

public class HealthServiceFake : IHealthService
{
    public Task<bool> IsHealthyAsync()
    {
        return Task.FromResult(true);
    }
}
