namespace SupplySyncBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string username, string email, string password, int roleId);
        Task<string?> LoginUserAsync(string email, string password);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
