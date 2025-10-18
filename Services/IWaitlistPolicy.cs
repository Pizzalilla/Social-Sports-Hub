using System.Collections.Generic;
using Social_Sport_Hub.Models;
using Social_Sport_Hub.Data.Models;


namespace Social_Sport_Hub.Services
{
    public interface IWaitlistPolicy
    {
        User? PromoteNextUser(IReadOnlyList<User> waitlistedUsers, IReadOnlyList<User> confirmedUsers, int maxCapacity);
    }
}
