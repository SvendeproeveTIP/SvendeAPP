using GeolocationTest.Views;

namespace GeolocationTest;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("main", typeof(MainPage));
        Routing.RegisterRoute("home", typeof(HomePage));
        Routing.RegisterRoute(nameof(Scan), typeof(Scan));
        Routing.RegisterRoute("orders", typeof(OrderPage));
        Routing.RegisterRoute("userspage", typeof(UsersPage));
        Routing.RegisterRoute(nameof(ManageUserPage), typeof(ManageUserPage));
        Routing.RegisterRoute("settings", typeof(SettingsPage));
        Routing.RegisterRoute(nameof(Transport), typeof(Transport));
        Routing.RegisterRoute(nameof(MobilePay), typeof(MobilePay));
        Routing.RegisterRoute(nameof(PopupPage), typeof(PopupPage));
    }
}
