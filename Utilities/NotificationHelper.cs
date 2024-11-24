using System.Threading.Tasks;

namespace SupplySyncBackend.Utilities
{
    public static class NotificationHelper
    {
        public static async Task SendEmailNotification(string toEmail, string subject, string message)
        {
            await EmailSender.SendEmailAsync(toEmail, subject, message);
        }

        public static void SendPushNotification(string deviceToken, string message)
        {
            // Example implementation; replace with an actual push notification library
            Console.WriteLine($"Push notification sent to {deviceToken}: {message}");
        }
    }
}
