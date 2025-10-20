using Social_Sport_Hub.Data.Models;

namespace Social_Sport_Hub.Models
{
    public static class SportEventExtensions
    {
        public static string GetCapacityDisplay(this SportEvent sportEvent, int attendeeCount)
        {
            return $"{attendeeCount}/{sportEvent.Capacity}";
        }
    }
}