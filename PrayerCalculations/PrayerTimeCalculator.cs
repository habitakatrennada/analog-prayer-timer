using AnalogPrayerTimer.Models;

namespace AnalogPrayerTimer.PrayerCalculations;

public class PrayerTimeCalculator
{
    public List<PrayerTime> CalculateTimes(DateTime date, Location location)
    {
        // نموذج مبسط للتعلم. سنبني حسابات فلكية لاحقاً.
        var noon = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);

        return new List<PrayerTime>
        {
            new PrayerTime { Name = "فجر", Time = noon.AddHours(-6) },
            new PrayerTime { Name = "شروق", Time = noon.AddHours(-5) },
            new PrayerTime { Name = "ظهر", Time = noon },
            new PrayerTime { Name = "عصر", Time = noon.AddHours(4) },
            new PrayerTime { Name = "مغرب", Time = noon.AddHours(6) },
            new PrayerTime { Name = "عشاء", Time = noon.AddHours(7) },
        };
    }
}
