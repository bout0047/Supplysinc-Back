using Xunit;
using Moq;
using SupplySyncBackend.Services;

public class RoleServiceTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly RoleService _roleService;

    public RoleServiceTests()
    {
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _roleService = new RoleService(_roleRepositoryMock.Object);
    }

    [Fact]
    public void AssignRole_Success()
    {
        _roleRepositoryMock.Setup(repo => repo.AssignRole("User1", "Admin")).Returns(true);

        var result = _roleService.AssignRole("User1", "Admin");

        Assert.True(result);
    }
}
