using System;

namespace Social_Sport_Hub.Models
{
    public sealed class HonorHistoryRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public int ChangeAmount { get; set; }    // +5 attendance, -10 no-show
        public string Reason { get; set; } = string.Empty;
        public DateTime RecordedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
