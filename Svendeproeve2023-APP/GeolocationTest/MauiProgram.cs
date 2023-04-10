using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using GeolocationTest.Services;
using GeolocationTest.Views;

namespace GeolocationTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiMaps()
			.UseBarcodeReader();
        builder.ConfigureMauiHandlers(handlers =>
		{
			handlers.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
			handlers.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
			handlers.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
#if ANDROID || IOS || MACCATALYST
			handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, CustomMapHandler>();
#endif
		});

#if DEBUG
            builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);

		//Services
		builder.Services.AddSingleton<TransportService>();

		//View Models
		builder.Services.AddSingleton<TransportViewModel>();
		builder.Services.AddSingleton<BetalingViewModel>();
		builder.Services.AddSingleton<BaseViewModel>();

		//Views Registration
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MobilePay>();
		builder.Services.AddSingleton<PopupPage>();
		builder.Services.AddSingleton<Scan>();
		builder.Services.AddSingleton<Transport>();

		return builder.Build();
	}
}
