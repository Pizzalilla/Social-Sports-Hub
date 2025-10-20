using Social_Sport_Hub.Data;
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Utilities;
using Microsoft.EntityFrameworkCore;

public class EventService
{
    private readonly SportsHubContext _context;
    private readonly GenericCache<SportEvent> _eventCache;

    public EventService(SportsHubContext context)
    {
        _context = context;
        _eventCache = new GenericCache<SportEvent>(e => e.Id);
    }

    public async Task AddEventAsync(SportEvent newEvent)
    {
        await _context.SportEvents.AddAsync(newEvent);
        await _context.SaveChangesAsync();

        // Add to cache
        _eventCache.Add(newEvent);

        System.Diagnostics.Debug.WriteLine($"✅ Event added: {newEvent.Title}");
    }


    public async Task<List<SportEvent>> GetAllEventsAsync()
    {
        _eventCache.Clear();

        var list = await _context.SportEvents
            .OrderBy(e => e.StartTimeUtc)
            .ToListAsync();

        // Populate cache
        foreach (var ev in list)
        {
            _eventCache.Add(ev);
        }

        System.Diagnostics.Debug.WriteLine($"📂 Loaded {list.Count} events from database");
        return list;
    }


    /// Returns a single event by its unique ID.
    public async Task<SportEvent?> GetEventByIdAsync(Guid id)
    {
        // Try cache first
        var cached = _eventCache.Get(id);
        if (cached != null)
            return cached;

        return await _context.SportEvents
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    /// Deletes an event by ID (if found).
    public async Task DeleteEventAsync(Guid id)
    {
        var ev = await _context.SportEvents.FirstOrDefaultAsync(e => e.Id == id);
        if (ev != null)
        {
            _context.SportEvents.Remove(ev);
            await _context.SaveChangesAsync();

            // ✅ Remove from cache
            _eventCache.Remove(id);

            System.Diagnostics.Debug.WriteLine($"🗑️ Event deleted: {ev.Title}");
        }
    }


    /// Clears the event cache (useful for testing or refresh).
    public void ClearCache()
    {
        _eventCache.Clear();
    }
}
