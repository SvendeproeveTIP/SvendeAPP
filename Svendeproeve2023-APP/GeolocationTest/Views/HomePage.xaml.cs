using Microsoft.Maui.Maps;
using GeolocationTest.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace GeolocationTest.Views;

public partial class HomePage : ContentPage
{
    //IGeolocation geolocation;
    //private bool _isCheckingLocation;
    MapViewModel vm;
    public HomePage(MapViewModel vm)
    {
        InitializeComponent();

        this.vm = vm;
        BindingContext= vm;

                //InitMap1();
        //GetCurrentLocation();
    }

    protected override void OnDisappearing()
    {
        vm.DisposeCancellationTokenCommand.Execute(null);

        base.OnDisappearing();
    }

    protected override void OnAppearing()
    {
        vm.GetCurrentLocationCommand.Execute(null);

        base.OnAppearing();
    }


    //public async Task GetCurrentLocation()
    //{

    //    try
    //    {
    //        _isCheckingLocation = true;

    //        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(1));

    //        Location position = await Geolocation.Default.GetLocationAsync(request);

    //        Location location = new Location(position.Latitude, position.Longitude);
    //        MapSpan mapSpan = new MapSpan(location, 0.1, 0.1);
    //        MyMap.MoveToRegion(mapSpan);


    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Unable to query location: {ex.Message}");
    //        await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
    //    }
    //    finally
    //    {
    //        _isCheckingLocation = false;
    //    }
    //}
    //void InitMap1()
    //{
    //    var customPinFromImage = new CustomPin()
    //    {
    //        Label = "EL-Løbehjul 1",
    //        Location = new Location(55.3782028776744, 10.396612222748393),
    //        Address = "59% Batteri tilbage",
    //        ImageSource = ImageSource.FromResource("GeolocationTest.Resources.Images.elscooter.png")
    //    };

    //    MyMap.Pins.Add(customPinFromImage);
    //}
}