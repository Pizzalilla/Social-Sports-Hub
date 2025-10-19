using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Storage;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Social_Sport_Hub.Views
{
    public partial class MapPage : ContentPage
    {
        // Replace with a secure retrieval in production (don't commit the key).
        const string GoogleMapsApiKeyPlaceholder = "AIzaSyCmKWHgwUOXxYT1nN7lV8I-_DLMtfN5ejY";

        public MapPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMapHtmlAsync();
        }

        async Task LoadMapHtmlAsync()
        {
            // Read the embedded asset (Resources/Raw/map.html)
            using var stream = await FileSystem.OpenAppPackageFileAsync("map.html");
            using var reader = new StreamReader(stream);
            var html = await reader.ReadToEndAsync();

            // Inject the Google Maps script tag with your API key at runtime.
            // IMPORTANT: Replace the token below with your API key securely.
            var apiKey = "AIzaSyCmKWHgwUOXxYT1nN7lV8I-_DLMtfN5ejY";
            var scriptTag = $"<script src=\"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initMap\" async defer></script>";

            // If html contains a known placeholder, replace it. Otherwise append before </body>.
            if (html.Contains("__MAP_SCRIPT_TAG_PLACEHOLDER__"))
            {
                html = html.Replace("__MAP_SCRIPT_TAG_PLACEHOLDER__", scriptTag);
            }
            else
            {
                html = html.Replace("</body>", scriptTag + Environment.NewLine + "</body>");
            }

            MapWebView.Source = new HtmlWebViewSource { Html = html };
        }

        // Example: call from code to add a marker
        public async Task AddMarkerAsync(double lat, double lng, string title = "")
        {
            // Ensure JS is ready; small delay can help if needed
            await Task.Delay(250);
            var js = $"addMarker({lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}, {lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}, \"{EscapeJsString(title)}\");";
            await MapWebView.EvaluateJavaScriptAsync(js);
        }

        public async Task SetCenterAsync(double lat, double lng, int? zoom = null)
        {
            var zoomArg = zoom.HasValue ? $", {zoom.Value}" : "";
            var js = $"setCenter({lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}, {lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}{zoomArg});";
            await MapWebView.EvaluateJavaScriptAsync(js);
        }

        static string EscapeJsString(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }
}