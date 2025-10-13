using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    public sealed class OpenMeteoWeatherService : IWeatherService
    {
        private readonly HttpClient _http;
        public OpenMeteoWeatherService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress ??= new Uri("https://api.open-meteo.com/v1/");
        }

        public async Task<WeatherSummary?> GetForecastAsync(double latitude, double longitude, DateTime dateTimeUtc)
        {
            var url = $"forecast?latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&hourly=temperature_2m,precipitation_probability,wind_speed_10m&timezone=UTC";
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            req.Headers.UserAgent.ParseAdd("SocialSportsHub/1.0 (kartikay.singh@satudent.uts.edu.au)");
            var res = await _http.SendAsync(req);
            if (!res.IsSuccessStatusCode) return null;

            using var doc = JsonDocument.Parse(await res.Content.ReadAsStringAsync());
            if (!doc.RootElement.TryGetProperty("hourly", out var hourly)) return null;

            double temp = Extract(hourly, "temperature_2m");
            int rain = (int)Math.Round(Extract(hourly, "precipitation_probability"));
            double wind = Extract(hourly, "wind_speed_10m");
            return new WeatherSummary(temp, rain, wind);
        }

        private static double Extract(JsonElement root, string name)
        {
            if (!root.TryGetProperty(name, out var arr) || arr.ValueKind != JsonValueKind.Array || arr.GetArrayLength() == 0) return double.NaN;
            var s = arr[0].ToString();
            return double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : double.NaN;
        }
    }
}
