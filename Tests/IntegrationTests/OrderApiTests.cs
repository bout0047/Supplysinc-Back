using Xunit;
using System.Net.Http;
using Newtonsoft.Json;

public class OrderApiTests
{
    private readonly HttpClient _client;

    public OrderApiTests(HttpClient client)
    {
        _client = client;
    }

    [Fact]
    public async Task GetOrders_ReturnsOrders()
    {
        var response = await _client.GetAsync("/api/orders");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(JsonConvert.DeserializeObject<List<Order>>(content));
    }
}
