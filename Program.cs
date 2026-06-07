using AnalogPrayerTimer.PrayerCalculations;
using AnalogPrayerTimer.Models;

Console.WriteLine("مرحباً بكم في مشروع Analog Prayer Timer!");
Console.WriteLine();

var location = new Location { Latitude = 24.7136, Longitude = 46.6753 };
var calculator = new PrayerTimeCalculator();
var today = DateTime.Today;
var prayerTimes = calculator.CalculateTimes(today, location);

Console.WriteLine($"التاريخ: {today:yyyy-MM-dd}");
Console.WriteLine($"الموقع: خط عرض {location.Latitude}, خط طول {location.Longitude}");
Console.WriteLine();

foreach (var prayer in prayerTimes)
{
    Console.WriteLine($"{prayer.Name,-10}: {prayer.Time:HH:mm}");
}

Console.WriteLine();
Console.WriteLine("يمكنك تعديل القيم في Program.cs والتجربة.");
