using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SupplySyncBackend.Controllers;
using SupplySyncBackend.Services;

public class AuthControllerTests
{
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly AuthController _authController;

    public AuthControllerTests()
    {
        _authServiceMock = new Mock<IAuthService>();
        _authController = new AuthController(_authServiceMock.Object);
    }

    [Fact]
    public async Task Login_ReturnsToken()
    {
        _authServiceMock.Setup(auth => auth.LoginAsync("testuser", "password"))
            .ReturnsAsync("testToken");

        var result = await _authController.Login(new LoginDto { Username = "testuser", Password = "password" }) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("testToken", result.Value);
    }
}
