using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;
using CommunityToolkit.Mvvm.Input;
using GeolocationTest.Models;
using CommunityToolkit.Mvvm.ComponentModel;

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


                var place = new LocationPin()
                {
                    Location = location,
                    Address = address,
                    Description = "Current Location"
                };

                Places.Add(place);

                var placeList = new List<LocationPin>() { place };
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
