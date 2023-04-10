using ZXing.Net.Maui;

namespace GeolocationTest.Views;

public partial class Scan : ContentPage
{
	public Scan()
	{
		InitializeComponent();

        barCodereader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode
        };
    }

    private void barCodereader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        barCodereader.IsDetecting = false;
        if (e.Results.Any())
        {
            var result = e.Results.FirstOrDefault();

            Dispatcher.Dispatch(async () =>
            {
                var navigationParam = new Dictionary<string, object>()
                {
                    {"qrCodeResult", result.Value }
                };

                await Shell.Current.GoToAsync(nameof(Transport), navigationParam);
            });
        }
    }
}