using SupplySyncBackend.Repositories;
using SupplySyncBackend.Models;
using SupplySyncBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return false;

            // Implement password hashing comparison logic here.
            return user.PasswordHash == password;
        }

        public async Task UpdatePasswordAsync(int userId, string newPasswordHash)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) throw new Exception("User not found.");

            user.PasswordHash = newPasswordHash;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
