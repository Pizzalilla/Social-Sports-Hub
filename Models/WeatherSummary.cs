namespace Social_Sport_Hub.Models
{
    // Simplified weather summary model for forecast integration.
    public readonly record struct WeatherSummary(
        double TemperatureCelsius,
        int RainProbability,
        double WindSpeedKph
    );
}
