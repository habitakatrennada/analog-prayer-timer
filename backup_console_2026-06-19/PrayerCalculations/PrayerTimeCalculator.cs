using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AnalogPrayerTimer.Models;

namespace AnalogPrayerTimer.PrayerCalculations;

public class PrayerTimeCalculator
{
    private const string ApiEndpoint = "https://api.aladhan.com/v1/timings";
    private static readonly HttpClient HttpClient = new();

    public async Task<List<PrayerTime>> CalculateTimesAsync(DateTime date, Location location)
    {
        string dateString = date.ToString("yyyy-MM-dd");
        string requestUri = $"{ApiEndpoint}?latitude={location.Latitude}&longitude={location.Longitude}&method=2&date={dateString}";

        using var response = await HttpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();

        var apiResponse = JsonSerializer.Deserialize<AladhanResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (apiResponse?.Code != 200 || apiResponse.Data?.Timings == null)
        {
            throw new InvalidOperationException("تعذر تفسير الاستجابة من API أوقات الصلاة.");
        }

        var timings = apiResponse.Data.Timings;
        return new List<PrayerTime>
        {
            new PrayerTime { Name = "فجر", Time = ParseTiming(timings.Fajr, date) },
            new PrayerTime { Name = "شروق", Time = ParseTiming(timings.Sunrise, date) },
            new PrayerTime { Name = "ظهر", Time = ParseTiming(timings.Dhuhr, date) },
            new PrayerTime { Name = "عصر", Time = ParseTiming(timings.Asr, date) },
            new PrayerTime { Name = "مغرب", Time = ParseTiming(timings.Maghrib, date) },
            new PrayerTime { Name = "عشاء", Time = ParseTiming(timings.Isha, date) },
        };
    }

    public List<PrayerTime> CalculateTimes(DateTime date, Location location)
    {
        var noon = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);

        return new List<PrayerTime>
        {
            new PrayerTime { Name = "فجر", Time = noon.AddHours(-6) },
            new PrayerTime { Name = "شروق", Time = noon.AddHours(-5) },
            new PrayerTime { Name = "ظهر", Time = noon.AddMinutes(30) },
            new PrayerTime { Name = "عصر", Time = noon.AddHours(4).AddMinutes(30) },
            new PrayerTime { Name = "مغرب", Time = noon.AddHours(6) },
            new PrayerTime { Name = "عشاء", Time = noon.AddHours(7) },
        };
    }

    private static DateTime ParseTiming(string time, DateTime date)
    {
        var cleaned = time.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
        if (TimeSpan.TryParse(cleaned, CultureInfo.InvariantCulture, out var timeOfDay))
        {
            return date.Date + timeOfDay;
        }

        throw new FormatException($"تعذر تفسير الوقت: {time}");
    }

    private class AladhanResponse
    {
        public int Code { get; set; }
        public string? Status { get; set; }
        public AladhanData? Data { get; set; }
    }

    private class AladhanData
    {
        public AladhanTimings? Timings { get; set; }
    }

    private class AladhanTimings
    {
        public string Fajr { get; set; } = string.Empty;
        public string Sunrise { get; set; } = string.Empty;
        public string Dhuhr { get; set; } = string.Empty;
        public string Asr { get; set; } = string.Empty;
        public string Maghrib { get; set; } = string.Empty;
        public string Isha { get; set; } = string.Empty;
    }
}
