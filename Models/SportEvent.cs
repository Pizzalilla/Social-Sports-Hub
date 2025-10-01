using System;
using System.ComponentModel.DataAnnotations;

namespace SocialSports.Maui.Models;

public class SportEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    public Sport Sport { get; set; }

    public DateTimeOffset StartTime { get; set; } = DateTimeOffset.UtcNow.AddDays(1);

    public int Capacity { get; set; } = 8;

    public int PlayersJoined { get; set; } = 1;

    public Guid HostId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [MaxLength(160)]
    public string? LocationName { get; set; }

    public int SpotsLeft => Math.Max(0, Capacity - PlayersJoined);
}
