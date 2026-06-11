using AnalogPrayerTimer.PrayerCalculations;
using AnalogPrayerTimer.Models;

Console.WriteLine("Wellcome to the Analog Prayer Timer application!");
Console.WriteLine();
//33.40367186308134, 6.822887362985581
var location = new Location { Latitude = 6.822887362985581, Longitude = 33.40367186308134 };
var calculator = new PrayerTimeCalculator();
var today = DateTime.Today;
var prayerTimes = calculator.CalculateTimes(today, location);

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
