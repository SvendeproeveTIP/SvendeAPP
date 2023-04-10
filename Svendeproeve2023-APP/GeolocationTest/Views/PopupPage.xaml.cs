using MauiPopup;
using MauiPopup.Views;

namespace GeolocationTest.Views;

public partial class PopupPage : BasePopupPage
{
	public PopupPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Application.Current.MainPage = new MainPage();
    }
}