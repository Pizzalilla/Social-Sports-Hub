using System;

namespace Social_Sport_Hub.Models
{
    // Tracks attendance status of a user for a specific sports event.
    public enum AttendanceStatus
    {
        Confirmed,
        Attended,
        NoShow
    }

    public sealed class AttendanceRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SportEventId { get; set; }
        public Guid UserId { get; set; }
        public AttendanceStatus Status { get; set; }
        public DateTime MarkedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
