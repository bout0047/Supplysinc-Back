using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using SupplySyncBackend;

public class AllIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public AllIntegrationTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthCheck_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/healthcheck");
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
    }
}
