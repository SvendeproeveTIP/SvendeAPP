using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;
using CommunityToolkit.Mvvm.Input;
using GeolocationTest.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.VisualBasic;

namespace GeolocationTest.ViewModels
{
    public partial class MapViewModel : BaseViewModel
    {
        public ObservableCollection<LocationPin> Places { get; } = new();

        [ObservableProperty]
        bool isReady;

        [ObservableProperty]
        ObservableCollection<LocationPin> bindablePlaces;

        private CancellationTokenSource cts;
        private IGeolocation geolocation;
        private IGeocoding geocoding;
        private LocationPin custompin;

        public MapViewModel(IGeolocation geolocation, IGeocoding geocoding) 
        {
            this.geolocation = geolocation;
            this.geocoding = geocoding;
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

                LocationPin[] information = new LocationPin[]
                {
                    new LocationPin { Description = "Løbehjul 1", Latitude = 55.46332847178871, Longitude = 10.078609547748593, Address = "100% Batteri tilbage" },
                    new LocationPin { Description = "Løbehjul 2", Latitude = 55.27602983331951, Longitude = 10.306575837826882, Address = "59% Batteri tilbage" },
                    // Add more locations as needed
                };

                foreach (var item in information)
                {
                    var custompin = new LocationPin()
                    {
                        Location = new Location(item.Latitude, item.Longitude),
                        Address = item.Address,
                        Description = item.Description,
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
