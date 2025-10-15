using System;
using System.Collections.Generic;
using System.Linq;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Extensions
{
    // Provides LINQ-style helpers for working with upcoming sports events.
    public static class SportEventEnumerableExtensions
    {
        public static IEnumerable<SportEvent> UpcomingWithin(
            this IEnumerable<SportEvent> events,
            double radiusKm,
            DateTime fromUtc,
            double originLat = 0,
            double originLon = 0)
        {
            foreach (var sportEvent in events.Where(e => e.StartTimeUtc > fromUtc))
            {
                var distance = CalculateHaversineDistance(
                    sportEvent.Latitude, sportEvent.Longitude, originLat, originLon);

                if (distance <= radiusKm)
                    yield return sportEvent;
            }
        }

        private static double CalculateHaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadiusKm = 6371.0;
            var dLat = (lat2 - lat1) * Math.PI / 180.0;
            var dLon = (lon2 - lon1) * Math.PI / 180.0;

            var a = Math.Pow(Math.Sin(dLat / 2), 2) +
                    Math.Cos(lat1 * Math.PI / 180.0) *
                    Math.Cos(lat2 * Math.PI / 180.0) *
                    Math.Pow(Math.Sin(dLon / 2), 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }
    }
}
