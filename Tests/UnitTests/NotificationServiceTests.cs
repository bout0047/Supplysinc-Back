using Xunit;
using Moq;
using SupplySyncBackend.Services;

public class NotificationServiceTests
{
    private readonly NotificationService _notificationService;

    public NotificationServiceTests()
    {
        _notificationService = new NotificationService();
    }

    [Fact]
    public void SendNotification_Success()
    {
        var result = _notificationService.SendNotification("User1", "Test Message");
        Assert.True(result);
    }
}
