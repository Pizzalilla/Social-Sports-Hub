using Microsoft.EntityFrameworkCore;
using SocialSports.Maui.Data;
using SocialSports.Maui.Models;

namespace SocialSports.Maui.Services;

public class AuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db) => _db = db;

    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user is null) return null;

        // Demo: compare 'password' to PasswordHash directly
        return user.PasswordHash == password ? user : null;
    }

    public async Task<User> SignupAsync(string email, string displayName, string password)
    {
        var existing = await _db.Users.AnyAsync(u => u.Email == email);
        if (existing) throw new InvalidOperationException("Email already in use");

        var user = new User { Email = email, DisplayName = displayName, PasswordHash = password };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }
}
