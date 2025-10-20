using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Sport_Hub.Data.Models
{
    public enum AttendanceStatus
    {
        Confirmed,
        Attended,
        NoShow
    }

    public sealed class AttendanceRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Foreign key to the event
        [Required]
        public Guid SportEventId { get; set; }

        // Foreign key to the user
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; } = AttendanceStatus.Confirmed;

        public DateTime MarkedAtUtc { get; set; } = DateTime.UtcNow;

        // Navigation properties for EF Core relationships
        [ForeignKey(nameof(SportEventId))]
        public SportEvent? SportEvent { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
