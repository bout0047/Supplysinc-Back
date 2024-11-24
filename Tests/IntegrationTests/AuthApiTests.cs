using Xunit;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

public class AuthApiTests
{
    private readonly HttpClient _client;

    public AuthApiTests(HttpClient client)
    {
        _client = client;
    }

    [Fact]
    public async Task Login_ReturnsToken()
    {
        var payload = new { Username = "testuser", Password = "Test@123" };
        var response = await _client.PostAsync("/api/auth/login",
            new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("token", content);
    }
}
