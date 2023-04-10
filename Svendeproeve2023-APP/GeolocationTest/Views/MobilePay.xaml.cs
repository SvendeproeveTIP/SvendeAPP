using GeolocationTest.ViewModels;
using MauiPopup;
using ZXing.Net.Maui;

namespace GeolocationTest.Views;

[QueryProperty(nameof(PrisResult), "prisResult")]
public partial class MobilePay : ContentPage
{
	private BetalingViewModel _viewModel;
	public MobilePay(BetalingViewModel viewModel)
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "transparent.png",
            IsEnabled = false
        });

        _viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    public string PrisResult
    {
        set
        {
            prisResult.Text = $"{value} kr";
        }
    }

    private void BetalInvoked(object sender, EventArgs e)
	{
       PopupAction.DisplayPopup(new PopupPage());
    }

    protected override bool OnBackButtonPressed()
    {
        //return base.OnBackButtonPressed();
        return true;
    }
}