using System.Threading.Tasks;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    // Handles registration and authentication of users.
    public interface IAuthService
    {
        Task<(bool IsSuccessful, string? ErrorMessage)> RegisterAsync(string email, string password, string displayName, bool asHost = false);
        Task<(bool IsSuccessful, User? AuthenticatedUser, string? ErrorMessage)> LoginAsync(string email, string password);
    }
}
