using SupplySyncBackend.Models;

namespace SupplySyncBackend.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task<bool> ValidateCredentialsAsync(string email, string password);
        Task UpdatePasswordAsync(int userId, string newPasswordHash);
    }
}
