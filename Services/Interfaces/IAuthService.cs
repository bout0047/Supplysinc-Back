namespace SupplySyncBackend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<bool> LogoutAsync(string token);
        Task<bool> ValidateTokenAsync(string token);
        Task<string> RefreshTokenAsync(string token);
        Task<bool> AssignRoleAsync(int userId, int roleId);
    }
}
