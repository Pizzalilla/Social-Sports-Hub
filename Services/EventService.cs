using Microsoft.EntityFrameworkCore;
using SocialSports.Maui.Data;
using SocialSports.Maui.Models;

namespace SocialSports.Maui.Services;

public class EventService
{
    private readonly AppDbContext _db;

    public EventService(AppDbContext db) => _db = db;

    public async Task<List<SportEvent>> GetUpcomingAsync(int page = 1, int size = 20)
    {
        var now = DateTimeOffset.UtcNow;
        return await _db.Events
            .Where(e => e.StartTime >= now)
            .OrderBy(e => e.StartTime)
            .Skip(Math.Max(0, (page - 1) * size))
            .Take(size)
            .ToListAsync();
    }

    public async Task<SportEvent> CreateAsync(SportEvent e)
    {
        _db.Events.Add(e);
        await _db.SaveChangesAsync();
        Utilities.EventBus.PublishEventCreated(e);
        return e;
    }

    public async Task<bool> JoinAsync(Guid eventId)
    {
        var e = await _db.Events.FirstOrDefaultAsync(x => x.Id == eventId);
        if (e is null) return false;
        if (e.PlayersJoined >= e.Capacity) return false;

        e.PlayersJoined += 1;
        await _db.SaveChangesAsync();
        return true;
    }
}
