using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.Notifications;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetNotifications(int userId)
        {
            var notifications = await _notificationService.GetAllNotifications(userId);
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDto notification)
        {
            var success = await _notificationService.CreateNotification(notification.Message, notification.NotificationId);
            return success ? Ok("Notification created successfully.") : BadRequest("Failed to create notification.");
        }
    }
}
