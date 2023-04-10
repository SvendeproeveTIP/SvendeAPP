using GeolocationTest.Views;

namespace GeolocationTest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        Application.Current.MainPage = new LoginPage();
    }
}
