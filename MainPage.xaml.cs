using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using AnalogPrayerTimer.Models;
using AnalogPrayerTimer.PrayerCalculations;

namespace AnalogPrayerTimer.Maui;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<PlaceResult> _results = new();
    private readonly ObservableCollection<PrayerTime> _prayerTimes = new();
    private Location? _selectedLocation;

    public MainPage()
    {
        InitializeComponent();
        ResultsCollection.ItemsSource = _results;
        PrayerTimesCollection.ItemsSource = _prayerTimes;
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        _results.Clear();
        _prayerTimes.Clear();
        _selectedLocation = null;
        CalculateButton.IsEnabled = false;

        var query = QueryEntry.Text?.Trim();
        if (string.IsNullOrEmpty(query))
        {
            await DisplayAlert("تنبيه", "ادخل اسم مكان", "حسناً");
            return;
        }

        // Simple photon search - reuse code from console version if needed
        try
        {
            using var client = new System.Net.Http.HttpClient();
            var uri = $"https://photon.komoot.io/api/?q={System.Uri.EscapeDataString(query)}&limit=5";
            var resp = await client.GetStringAsync(uri);
            var pr = System.Text.Json.JsonSerializer.Deserialize<PhotonResponse>(resp, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (pr?.Features != null)
            {
                foreach (var f in pr.Features)
                {
                    if (f.Properties != null && f.Geometry?.Coordinates?.Count >= 2)
                    {
                        var display = f.Properties.Name;
                        if (!string.IsNullOrWhiteSpace(f.Properties.State)) display += ", " + f.Properties.State;
                        if (!string.IsNullOrWhiteSpace(f.Properties.Country)) display += ", " + f.Properties.Country;
                        _results.Add(new PlaceResult(display, f.Geometry.Coordinates[1], f.Geometry.Coordinates[0]));
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            await DisplayAlert("خطأ", ex.Message, "حسناً");
        }
    }

    private async void OnCalculateClicked(object sender, EventArgs e)
    {
        if (_selectedLocation == null)
        {
            await DisplayAlert("تنبيه", "اختر موقعاً أولاً.", "حسناً");
            return;
        }

        _prayerTimes.Clear();
        var calc = new PrayerTimeCalculator();
        var times = await calc.CalculateTimesAsync(System.DateTime.Today, _selectedLocation);
        foreach (var t in times)
            _prayerTimes.Add(t);
    }

    private void ResultsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.Count > 0 && e.CurrentSelection[0] is PlaceResult p)
        {
            _selectedLocation = new Location { Latitude = p.Latitude, Longitude = p.Longitude };
            CalculateButton.IsEnabled = true;
        }
    }

    private record PhotonResponse(List<PhotonFeature>? Features);
    private record PhotonFeature(PhotonProperties? Properties, PhotonGeometry? Geometry);
    private record PhotonProperties(string? Name, string? State, string? Country);
    private record PhotonGeometry(List<double>? Coordinates);
    private record PlaceResult(string DisplayName, double Latitude, double Longitude);
}
