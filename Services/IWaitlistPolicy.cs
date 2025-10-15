using System.Collections.Generic;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    public interface IWaitlistPolicy
    {
        User? PromoteNextUser(IReadOnlyList<User> waitlistedUsers, IReadOnlyList<User> confirmedUsers, int maxCapacity);
    }
}
