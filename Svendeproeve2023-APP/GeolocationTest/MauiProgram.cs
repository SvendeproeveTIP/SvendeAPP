using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using GeolocationTest.Services;
using GeolocationTest.Views;
using CommunityToolkit.Maui;
using GeolocationTest.Helper;
using GeolocationTest.ViewModels;

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
			.UseMauiCommunityToolkit()
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
        builder.Services.AddSingleton<IGeocoding>(Geocoding.Default);

		//Services
		builder.Services.AddSingleton<TransportService>();
		builder.Services.AddSingleton<CustomGroupComparer>();

		//View Models
		builder.Services.AddTransient<TransportViewModel>();
		builder.Services.AddTransient<BetalingViewModel>();
		builder.Services.AddTransient<OrderViewModel>();
        builder.Services.AddTransient<MapViewModel>();

        //Views Registration
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<Scan>();
        builder.Services.AddSingleton<OrderPage>();
        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<Transport>();
        builder.Services.AddSingleton<MobilePay>();
        builder.Services.AddSingleton<PopupPage>();

        return builder.Build();
	}
}
