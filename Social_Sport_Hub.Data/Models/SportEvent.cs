using Social_Sport_Hub.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Social_Sport_Hub.Data.Models
{
    public sealed class SportEvent
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string SportType { get; set; } = string.Empty;

        [Required]
        public DateTime StartTimeUtc { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; } = 10;

        public Guid HostUserId { get; set; }

        public SportEventRoster Roster { get; set; } = new();

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // ✅ EF Core relationship with AttendanceRecord
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }

    public sealed class SportEventRoster : IEnumerable<User>
    {
        private readonly List<User> _confirmed = new();
        private readonly List<User> _waitlist = new();

        public IReadOnlyList<User> ConfirmedPlayers => _confirmed;
        public IReadOnlyList<User> WaitlistedPlayers => _waitlist;

        public void AddConfirmed(User user) => _confirmed.Add(user);
        public void AddWaitlisted(User user) => _waitlist.Add(user);

        public IEnumerator<User> GetEnumerator()
        {
            foreach (var u in _confirmed)
                yield return u;

            foreach (var u in _waitlist)
                yield return u;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
