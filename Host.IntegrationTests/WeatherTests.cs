namespace Host.IntegrationTests;

using Host.IntegrationTests.Fixtures;

public class ApiIntegrationTest : IClassFixture<WebApplicationFactoryFixture>
{
    private readonly HttpClient _httpClient;

    public ApiIntegrationTest(WebApplicationFactoryFixture factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Act
        var response = await _httpClient.GetAsync("/weatherforecast");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content?.Headers?.ContentType?.ToString());
    }

    [Fact]
    public async Task Get_HealthCheckReturnsSuccess()
    {
        // Act
        var response = await _httpClient.GetAsync("/healthz");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/plain",
            response.Content?.Headers?.ContentType?.ToString());
    }
}