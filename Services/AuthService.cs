using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool IsSuccessful, string? ErrorMessage)> RegisterAsync(string email, string password, string displayName, bool asHost = false)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return (false, "Invalid email format.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return (false, "Password must be at least 8 characters long.");

            if (string.IsNullOrWhiteSpace(displayName))
                return (false, "Display name cannot be empty.");

            var alreadyExists = await _userRepository.Query().AnyAsync(u => u.Email == email);
            if (alreadyExists)
                return (false, "Email is already registered.");

            var salt = Guid.NewGuid().ToString("N");
            var hash = User.HashPassword(password, salt) + ":" + salt;

            User newUser = asHost ? new HostUser() : new PlayerUser();
            newUser.Email = email.Trim();
            newUser.DisplayName = displayName.Trim();
            newUser.PasswordHash = hash;

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool IsSuccessful, User? AuthenticatedUser, string? ErrorMessage)> LoginAsync(string email, string password)
        {
            var user = await _userRepository.Query().FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return (false, null, "User not found.");

            var parts = user.PasswordHash.Split(':');
            if (parts.Length != 2)
                return (false, null, "Invalid password hash.");

            var computedHash = User.HashPassword(password, parts[1]);
            if (!string.Equals(computedHash, parts[0], StringComparison.Ordinal))
                return (false, null, "Incorrect password.");

            return (true, user, null);
        }
    }
}
