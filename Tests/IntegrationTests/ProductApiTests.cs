using Xunit;
using System.Net.Http;
using Newtonsoft.Json;

public class ProductApiTests
{
    private readonly HttpClient _client;

    public ProductApiTests(HttpClient client)
    {
        _client = client;
    }

    [Fact]
    public async Task GetProducts_ReturnsProductList()
    {
        var response = await _client.GetAsync("/api/products");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(JsonConvert.DeserializeObject<List<Product>>(content));
    }
}
