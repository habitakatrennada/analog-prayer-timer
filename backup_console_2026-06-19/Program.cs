using System.Net.Http;
using System.Text.Json;
using AnalogPrayerTimer.PrayerCalculations;
using AnalogPrayerTimer.Models;

Console.WriteLine("Wellcome to the Analog Prayer Timer application!");
Console.WriteLine();

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("AnalogPrayerTimer/1.0 (contact: example@example.com)");
var location = await GetLocationAsync(httpClient);
var calculator = new PrayerTimeCalculator();
var today = DateTime.Today;

List<PrayerTime> prayerTimes;

try
{
    prayerTimes = await calculator.CalculateTimesAsync(today, location);
}
catch (Exception ex)
{
    Console.WriteLine("تعذر الحصول على أوقات الصلاة من الخادم. سيتم عرض أوقات تقريبية محلية.");
    Console.WriteLine($"الخطأ: {ex.Message}");
    prayerTimes = calculator.CalculateTimes(today, location);
}

Console.WriteLine($"التاريخ: {today:yyyy-MM-dd}");
Console.WriteLine($"الموقع: خط عرض {location.Latitude}, خط طول {location.Longitude}");
Console.WriteLine();
// عرض أوقات الصلاة بشكل منسق
foreach (var prayer in prayerTimes)
{
    Console.WriteLine($"{prayer.Name,-10}: {prayer.Time:HH:mm}");
}

Console.WriteLine();
Console.WriteLine("يمكنك تعديل القيم في Program.cs والتجربة.");

static async Task<Location> GetLocationAsync(HttpClient httpClient)
{
    const double DefaultLatitude = 33.397222;
    const double DefaultLongitude = 6.813028;

    while (true)
    {
        Console.Write("أدخل اسم الولاية أو البلدية أو المدينة أو عاصمة الولاية (أو اضغط Enter لاستخدام الموقع الافتراضي): ");
        var query = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(query))
        {
            Console.WriteLine("سيتم استخدام الإحداثيات الافتراضية لقونين.");
            return new Location { Latitude = DefaultLatitude, Longitude = DefaultLongitude };
        }

        var suggestions = await SearchPlaceAsync(query, httpClient);
        if (suggestions.Count == 0)
        {
            Console.WriteLine("لم يتم العثور على نتيجة. حاول اسمًا آخر.");
            continue;
        }

        if (suggestions.Count == 1)
        {
            var place = suggestions[0];
            Console.WriteLine($"تم العثور على المكان: {place.DisplayName}");
            return new Location { Latitude = place.Latitude, Longitude = place.Longitude };
        }

        Console.WriteLine("تم العثور على أكثر من مكان. اختر الرقم الأقرب إلى المكان الصحيح:");
        for (var i = 0; i < suggestions.Count; i++)
        {
            var place = suggestions[i];
            Console.WriteLine($"{i + 1}. {place.DisplayName} ({place.Latitude}, {place.Longitude})");
        }

        while (true)
        {
            Console.Write("أدخل رقم الاختيار: ");
            var choiceText = Console.ReadLine()?.Trim();
            if (int.TryParse(choiceText, out var choice) && choice >= 1 && choice <= suggestions.Count)
            {
                var selected = suggestions[choice - 1];
                return new Location { Latitude = selected.Latitude, Longitude = selected.Longitude };
            }

            Console.WriteLine("الاختيار غير صالح. حاول مرة أخرى.");
        }
    }
}

static async Task<List<PlaceResult>> SearchPlaceAsync(string query, HttpClient httpClient)
{
    var uri = $"https://photon.komoot.io/api/?q={Uri.EscapeDataString(query)}&limit=5";

    try
    {
        using var response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var photonResponse = JsonSerializer.Deserialize<PhotonResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return photonResponse?.Features?.Select(feature =>
        {
            var props = feature.Properties;
            var coords = feature.Geometry?.Coordinates;
            if (props == null || coords == null || coords.Count < 2)
                return null;

            var displayName = props.Name;
            if (!string.IsNullOrWhiteSpace(props.State))
                displayName += $", {props.State}";
            if (!string.IsNullOrWhiteSpace(props.Country))
                displayName += $", {props.Country}";

            return new PlaceResult(
                displayName,
                coords[1],
                coords[0]);
        })
        .Where(result => result != null)
        .Cast<PlaceResult>()
        .ToList() ?? new List<PlaceResult>();
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"حدث خطأ أثناء البحث عن الموقع: {ex.Message}");
        Console.WriteLine("حاول البحث مرة أخرى أو اضغط Enter لاستخدام الموقع الافتراضي.");
        return new List<PlaceResult>();
    }
}

record PlaceResult(string DisplayName, double Latitude, double Longitude);

record PhotonResponse(List<PhotonFeature>? Features);
record PhotonFeature(PhotonProperties? Properties, PhotonGeometry? Geometry);
record PhotonProperties(string? Name, string? State, string? Country);
record PhotonGeometry(List<double>? Coordinates);
