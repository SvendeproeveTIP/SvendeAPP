using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;
using CommunityToolkit.Mvvm.Input;
using GeolocationTest.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.VisualBasic;
using GeolocationTest.Services;

namespace GeolocationTest.ViewModels
{
    public partial class MapViewModel : BaseViewModel
    {
        private readonly IRestDataService _dataService;
        public ObservableCollection<LocationPin> Places { get; } = new();

        [ObservableProperty]
        bool isReady;

        [ObservableProperty]
        ObservableCollection<LocationPin> bindablePlaces;

        private CancellationTokenSource cts;
        private IGeolocation geolocation;
        private IGeocoding geocoding;
        private LocationPin custompin;

        public MapViewModel(IGeolocation geolocation, IGeocoding geocoding, IRestDataService dataService) 
        {
            this.geolocation = geolocation;
            this.geocoding = geocoding;

            _dataService = dataService;
        }
        
        [RelayCommand]
        private async Task GetCurrentLocationAsync()
        {

            try
            {
                cts = new CancellationTokenSource();

                var request = new GeolocationRequest(
                    GeolocationAccuracy.Medium,
                    TimeSpan.FromSeconds(1));

                var location = await geolocation.GetLocationAsync(request, cts.Token);
                var placemarks = await geocoding.GetPlacemarksAsync(location);
                var address = placemarks?.FirstOrDefault()?.AdminArea;

                Places.Clear();

                var information = await _dataService.GetAllVehicles();

                foreach (var item in information)
                {
                    var custompin = new LocationPin()
                    {
                        Location = new Location(item.Lattitude, item.Longtitude),
                        Address = $"{item.Battery}%",
                        Description = item.VehicleName,
                        Type = PinType.Place,
                        ImageSource = "elscooter.png"
                    };

                    Places.Add(custompin);
                }

                var place = new LocationPin()
                {
                    Location = location,
                    Address = address,
                    Description = "Current Location"
                };

                Places.Add(place);

                var placeList = new List<LocationPin>() { place, custompin };
                BindablePlaces = new ObservableCollection<LocationPin>(placeList);
                IsReady = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to query location: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }   
        }

        [RelayCommand]
        private void DisposeCancellationToken()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
        }
    }
}
