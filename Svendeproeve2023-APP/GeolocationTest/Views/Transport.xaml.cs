using Microsoft.Maui.Dispatching;
using System.Diagnostics;
using ZXing;

namespace GeolocationTest.Views;

[QueryProperty(nameof(QrCodeResult), "qrCodeResult")]
public partial class Transport : ContentPage
{
    Stopwatch stopwatch;
    float pris;
    float result = 0.00f;
    public Transport()
	{
		InitializeComponent();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "transparent.png",
            IsEnabled = false
        });

        stopwatch = new Stopwatch();

        pris = 0.50f;

        stopwatch.Start();
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (pointer.Value == 18000)
            {
                stopwatch.Stop();
                pointer.Value = 18000;
            }
            else
            {
                if (pointer.Value > 0 && pointer.Value % 10 == 0 )
                {
                    result += pris;
                }
                pointer.Value++;
                TimeSpan ts = stopwatch.Elapsed;

                string elapsedTime = ts.ToString(@"hh\:mm\:ss");

                timerLabel.Text = elapsedTime;

                prisLabel.Text = result.ToString() + "kr";
            }
            return true;
        });
    }
    private void betalBTN(object sender, EventArgs e)
    {
        stopwatch.Stop();
        Dispatcher.Dispatch(async () =>
        {
            var navigationParam = new Dictionary<string, object>()
        {
                    {"prisResult", result.ToString() }
                };

            await Shell.Current.GoToAsync(nameof(MobilePay), navigationParam);
        });
    }
    public string QrCodeResult
    {
        set
        {
            barcodeResult.Text = $"Transport Information\n{value}";
        }
    }


    protected override bool OnBackButtonPressed()
    {
        //return base.OnBackButtonPressed();
        return true;
    }
}