using System.Threading.Tasks;

namespace Social_Sport_Hub.Services
{
    public interface IGeocodingService
    {
        Task<(double Latitude, double Longitude)?> GeocodeAsync(string address);
        Task<string?> ReverseGeocodeAsync(double latitude, double longitude);
    }
}
