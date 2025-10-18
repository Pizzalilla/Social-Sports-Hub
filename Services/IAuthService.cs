using Social_Sport_Hub.Data.Models;

namespace Social_Sport_Hub.Services
{
    public interface IAuthService
    {
        Task<(bool ok, string? error)> RegisterAsync(
            string email, string password, string displayName, bool asHost = false);

        Task<(bool ok, User? user, string? error)> LoginAsync(
            string email, string password);
    }
}
