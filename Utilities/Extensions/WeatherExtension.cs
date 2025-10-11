using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Extensions
{
    public static class WeatherExtensions
    {
        public static string ToEmoji(this WeatherSummary summary)
        {
            if (summary.RainProbability >= 60)
                return "🌧️";
            if (summary.WindSpeedKph >= 30)
                return "💨";
            if (summary.TemperatureCelsius >= 30)
                return "🔥";
            if (summary.TemperatureCelsius <= 5)
                return "❄️";

            return "⛅";
        }
    }
}
