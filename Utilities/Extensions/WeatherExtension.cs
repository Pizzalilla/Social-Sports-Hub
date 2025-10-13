using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Extensions
{
    public static class WeatherExtension
    {
        public static string ToEmoji(this WeatherSummary summary)
        {
            if (summary.RainProbability > 50) return "🌧️";
            if (summary.TemperatureCelsius > 30) return "☀️";
            if (summary.TemperatureCelsius < 10) return "❄️";
            if (summary.WindSpeedKph > 25) return "💨";
            return "🌤️";
        }
    }
}
