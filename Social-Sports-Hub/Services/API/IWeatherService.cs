using System;
using System.Threading.Tasks;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    public interface IWeatherService
    {
        Task<WeatherSummary?> GetForecastAsync(double latitude, double longitude, DateTime dateTimeUtc);
    }
}
