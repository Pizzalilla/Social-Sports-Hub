using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Social_Sport_Hub.Data.Models
{
    public sealed class HonorHistoryRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int ChangeAmount { get; set; } // +5 attendance, -10 no-show

        [Required]
        [MaxLength(200)]
        public string Reason { get; set; } = string.Empty;

        public DateTime RecordedAtUtc { get; set; } = DateTime.UtcNow;

        // ✅ Optional navigation property for EF Core linking
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
