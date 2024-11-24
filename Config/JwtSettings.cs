namespace SupplySyncBackend.Config
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
