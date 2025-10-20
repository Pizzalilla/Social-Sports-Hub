using System;

namespace Social_Sport_Hub.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFriendlyLocal(this DateTime utc)
        {
            var localTime = utc.ToLocalTime();
            var now = DateTime.Now;

            if (localTime.Date == now.Date)
                return $"Today {localTime:hh:mm tt}";
            if (localTime.Date == now.AddDays(1).Date)
                return $"Tomorrow {localTime:hh:mm tt}";

            return $"{localTime:ddd, dd MMM yyyy hh:mm tt}";
        }
    }
}
