using GeolocationTest.Views;

namespace GeolocationTest;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Transport), typeof(Transport));
		Routing.RegisterRoute(nameof(MobilePay), typeof(MobilePay));
		Routing.RegisterRoute(nameof(Scan), typeof(Scan));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(PopupPage), typeof(PopupPage));
	}
}
