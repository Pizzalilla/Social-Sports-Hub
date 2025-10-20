using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data.Models;

namespace Social_Sport_Hub.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly IRepository<User> _users;

        public AuthService(IRepository<User> users) => _users = users;

        public async Task<(bool ok, string? error)> RegisterAsync(
            string email, string password, string displayName, bool asHost = false)
        {
            email = email?.Trim().ToLowerInvariant() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return (false, "Email and password are required.");

            var exists = await _users.Query().AnyAsync(u => u.Email == email);
            if (exists)
                return (false, "Email already registered.");

            var salt = Guid.NewGuid().ToString("N");
            var hash = User.HashPassword(password, salt);

            User newUser = asHost ? new HostUser() : new PlayerUser();
            newUser.Email = email;
            newUser.DisplayName = string.IsNullOrWhiteSpace(displayName) ? email : displayName;
            newUser.PasswordHash = $"{hash}:{salt}";

            await _users.AddAsync(newUser);
            await _users.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool ok, User? user, string? error)> LoginAsync(string email, string password)
        {
            email = email?.Trim().ToLowerInvariant() ?? string.Empty;

            var user = await _users.Query().FirstOrDefaultAsync(u => u.Email == email);
            if (user is null)
                return (false, null, "Account not found.");

            var parts = user.PasswordHash.Split(':');
            if (parts.Length != 2)
                return (false, null, "Credential error.");

            var computed = User.HashPassword(password, parts[1]);
            if (!string.Equals(computed, parts[0], StringComparison.Ordinal))
                return (false, null, "Incorrect password.");

            return (true, user, null);
        }
    }
}
