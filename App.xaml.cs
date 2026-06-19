using Microsoft.Maui.Controls;

namespace AnalogPrayerTimer.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new MainPage());
    }
}
