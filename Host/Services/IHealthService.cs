namespace Host.Services;

public interface IHealthService
{
    Task<bool> IsHealthyAsync();
}
