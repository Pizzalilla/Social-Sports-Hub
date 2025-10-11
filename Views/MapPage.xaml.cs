using Microsoft.Maui.Controls;
using System.IO;

namespace Social_Sport_Hub.Views;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();

        // Load the embedded HTML file from app package
        var stream = FileSystem.OpenAppPackageFileAsync("map.html").Result;
        using var reader = new StreamReader(stream);
        var html = reader.ReadToEnd();

        MapView.Source = new HtmlWebViewSource { Html = html };
    }
}
