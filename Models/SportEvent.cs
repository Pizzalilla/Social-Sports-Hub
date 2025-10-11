using System;
using System.Collections;
using System.Collections.Generic;

namespace Social_Sport_Hub.Models
{
    // Represents a sports event created by a host.
    public sealed class SportEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public DateTime StartTimeUtc { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Capacity { get; set; } = 10;
        public Guid HostUserId { get; set; }
        public SportEventRoster Roster { get; set; } = new SportEventRoster();
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }

    // Custom enumerable to iterate confirmed players first, then waitlist.
    public sealed class SportEventRoster : IEnumerable<User>
    {
        private readonly List<User> _confirmedPlayers = new();
        private readonly List<User> _waitlistedPlayers = new();

        public IReadOnlyList<User> ConfirmedPlayers => _confirmedPlayers;
        public IReadOnlyList<User> WaitlistedPlayers => _waitlistedPlayers;

        public void AddConfirmed(User player) => _confirmedPlayers.Add(player);
        public void AddWaitlisted(User player) => _waitlistedPlayers.Add(player);

        public IEnumerator<User> GetEnumerator()
        {
            foreach (var confirmed in _confirmedPlayers)
                yield return confirmed;

            foreach (var waitlisted in _waitlistedPlayers)
                yield return waitlisted;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
