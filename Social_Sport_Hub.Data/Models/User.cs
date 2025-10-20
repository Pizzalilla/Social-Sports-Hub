using System;
using System.Security.Cryptography;
using System.Text;

namespace Social_Sport_Hub.Data.Models
{
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

        // Demo-only password hashing
        public static string HashPassword(string password, string salt)
        {
            using var sha = SHA256.Create();
            var data = Encoding.UTF8.GetBytes($"{password}:{salt}");
            return Convert.ToHexString(sha.ComputeHash(data));
        }
    }

    public sealed class HostUser : User
    {
        public override bool CanHostEvents() => true;
        public override int MaxActiveJoins() => 10;
    }

    public sealed class PlayerUser : User
    {
        public override bool CanHostEvents() => false;
        public override int MaxActiveJoins() => 3;
    }
}
