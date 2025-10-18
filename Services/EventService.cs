using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;              // ✅ For SportsHubContext
using Social_Sport_Hub.Data.Models;       // ✅ For SportEvent
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Sport_Hub.Services
{
    /// <summary>
    /// Handles all database operations related to SportEvent entities.
    /// </summary>
    public class EventService
    {
        private readonly SportsHubContext _context;

        public EventService(SportsHubContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new event to the database.
        /// </summary>
        public async Task AddEventAsync(SportEvent newEvent)
        {
            await _context.SportEvents.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            System.Diagnostics.Debug.WriteLine($"✅ Event added: {newEvent.Title}");
        }

        /// <summary>
        /// Returns all events (sorted by start time ascending).
        /// </summary>
        public async Task<List<SportEvent>> GetAllEventsAsync()
        {
            var list = await _context.SportEvents
                .OrderBy(e => e.StartTimeUtc)
                .ToListAsync();

            System.Diagnostics.Debug.WriteLine($"📂 Loaded {list.Count} events from database");
            return list;
        }

        /// <summary>
        /// Returns a single event by its unique ID.
        /// </summary>
        public async Task<SportEvent?> GetEventByIdAsync(Guid id)
        {
            return await _context.SportEvents
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Deletes an event by ID (if found).
        /// </summary>
        public async Task DeleteEventAsync(Guid id)
        {
            var ev = await _context.SportEvents.FirstOrDefaultAsync(e => e.Id == id);
            if (ev != null)
            {
                _context.SportEvents.Remove(ev);
                await _context.SaveChangesAsync();
            }
        }
    }
}
