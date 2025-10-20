using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;               // ✅ Needed for SportsHubContext
using Social_Sport_Hub.Data.Models;        // ✅ Models (User, AttendanceRecord, etc.)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Sport_Hub.Data.Repositories
{
    /// <summary>
    /// Repository for managing AttendanceRecord entities (join/leave events).
    /// </summary>
    public class AttendanceRepository
    {
        private readonly SportsHubContext _context;

        public AttendanceRepository(SportsHubContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a user attendance record for a specific event if not already joined.
        /// </summary>
        public async Task AddAttendanceAsync(Guid eventId, Guid userId)
        {
            var exists = await _context.AttendanceRecords
                .AnyAsync(a => a.SportEventId == eventId && a.UserId == userId);

            if (!exists)
            {
                var record = new AttendanceRecord
                {
                    SportEventId = eventId,
                    UserId = userId,
                    Status = AttendanceStatus.Confirmed
                };

                _context.AttendanceRecords.Add(record);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes a user's attendance from an event.
        /// </summary>
        public async Task RemoveAttendanceAsync(Guid eventId, Guid userId)
        {
            var record = await _context.AttendanceRecords
                .FirstOrDefaultAsync(a => a.SportEventId == eventId && a.UserId == userId);

            if (record != null)
            {
                _context.AttendanceRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves all users attending a given event.
        /// </summary>
        public async Task<List<User>> GetAttendeesAsync(Guid eventId)
        {
            return await _context.AttendanceRecords
                .Where(a => a.SportEventId == eventId && a.User != null)
                .Select(a => a.User!)
                .ToListAsync();
        }
    }
}
