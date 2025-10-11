using System;

namespace Social_Sport_Hub.Models
{
    // Stores every change to a user's honor score for transparency.
    public sealed class HonorHistoryRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public int ChangeAmount { get; set; }     // +5 for attendance, -10 for no-show
        public string Reason { get; set; } = string.Empty;
        public DateTime RecordedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
