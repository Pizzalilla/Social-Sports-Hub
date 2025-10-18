using System.Collections.Generic;
using System.Linq;
using Social_Sport_Hub.Models;
using Social_Sport_Hub.Data.Models;


namespace Social_Sport_Hub.Services
{
    public sealed class HonorPriorityPolicy : IWaitlistPolicy
    {
        public User? PromoteNextUser(IReadOnlyList<User> waitlistedUsers, IReadOnlyList<User> confirmedUsers, int maxCapacity)
        {
            if (confirmedUsers.Count >= maxCapacity) return null;

            return waitlistedUsers
                .Select((u, idx) => new { u, idx })
                .OrderByDescending(x => x.u.HonorScore)
                .ThenBy(x => x.idx)
                .Select(x => x.u)
                .FirstOrDefault();
        }
    }
}
