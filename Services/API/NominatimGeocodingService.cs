using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Social_Sport_Hub.Services
{
    public sealed class NominatimGeocodingService : IGeocodingService
    {
        private readonly HttpClient _http;

        public NominatimGeocodingService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress ??= new Uri("https://nominatim.openstreetmap.org/");
        }

        public async Task<(double Latitude, double Longitude)?> GeocodeAsync(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return null;
            var req = new HttpRequestMessage(HttpMethod.Get, $"search?q={Uri.EscapeDataString(address)}&format=json&limit=1");
            req.Headers.UserAgent.ParseAdd("SocialSportsHub/1.0 (kartikay.singh@satudent.uts.edu.au)");
            var res = await _http.SendAsync(req);
            if (!res.IsSuccessStatusCode) return null;
            using var doc = JsonDocument.Parse(await res.Content.ReadAsStringAsync());
            if (doc.RootElement.ValueKind != JsonValueKind.Array || doc.RootElement.GetArrayLength() == 0) return null;
            var el = doc.RootElement[0];
            var lat = double.Parse(el.GetProperty("lat").GetString() ?? "0", CultureInfo.InvariantCulture);
            var lon = double.Parse(el.GetProperty("lon").GetString() ?? "0", CultureInfo.InvariantCulture);
            return (lat, lon);
        }

        public async Task<string?> ReverseGeocodeAsync(double latitude, double longitude)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, $"reverse?lat={latitude.ToString(CultureInfo.InvariantCulture)}&lon={longitude.ToString(CultureInfo.InvariantCulture)}&format=jsonv2");
            req.Headers.UserAgent.ParseAdd("SocialSportsHub/1.0 (kartikay.singh@satudent.uts.edu.au)");
            var res = await _http.SendAsync(req);
            if (!res.IsSuccessStatusCode) return null;
            using var doc = JsonDocument.Parse(await res.Content.ReadAsStringAsync());
            if (doc.RootElement.TryGetProperty("display_name", out var n)) return n.GetString();
            return null;
        }
    }
}
