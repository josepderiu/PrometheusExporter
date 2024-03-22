namespace Host.Services;

public sealed class HealthService : IHealthService
{
    public async Task<bool> IsHealthyAsync()
    {
        Random random = new();
        int randomNumber = random.Next(0, 2);
        return await Task.FromResult(randomNumber == 0);
    }
}