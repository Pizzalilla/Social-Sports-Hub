using System;
using System.ComponentModel.DataAnnotations;

namespace SocialSports.Maui.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(120)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(80)]
    public string DisplayName { get; set; } = string.Empty;

    // For demo only; in real apps, store a salted hash
    public string PasswordHash { get; set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
