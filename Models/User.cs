using System;
using System.Security.Cryptography;
using System.Text;

namespace Social_Sport_Hub.Models
{
    // Represents a generic user account.
    public abstract class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public int HonorScore { get; set; } = 100;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public virtual bool CanHostEvents() => false;
        public virtual int MaxActiveJoins() => 3;

        // Simple salted SHA256 hash — demo use only.
        public static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes($"{password}:{salt}");
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hashBytes);
        }
    }

    // Specialized user that can host sports events.
    public sealed class HostUser : User
    {
        public override bool CanHostEvents() => true;
        public override int MaxActiveJoins() => 10;
    }

    // Standard player who can join events but not host them.
    public sealed class PlayerUser : User
    {
        public override bool CanHostEvents() => false;
        public override int MaxActiveJoins() => 3;
    }
}
