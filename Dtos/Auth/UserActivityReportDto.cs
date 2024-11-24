namespace SupplySyncBackend.Dtos.Auth
{
    public class UserActivityReportDto
    {
        public int UserId { get; set; }
        public DateTime LastLogin { get; set; }
        public int ActionsPerformed { get; set; }
    }
}
