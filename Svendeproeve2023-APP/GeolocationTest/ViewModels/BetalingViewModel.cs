using GeolocationTest.Services;
using GeolocationTest.Views;
using MauiPopup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.ViewModels
{
    public partial class BetalingViewModel : BaseViewModel
    {
        private readonly IRestDataService _dataService;
        public BetalingViewModel(IRestDataService dataService) 
        {
            _dataService = dataService;
        }

        Ordres ordre = new Ordres
        {
            OrderDate = DateTime.Now,
            OrderEnded = true,
            EndDate = DateTime.Now,
            Price = 5.0,
            UserId = 1,
            VehicleId = 3
        };

        [RelayCommand]
        public async void Betal()
        {
            Debug.WriteLine("---> Add new Item");
            await _dataService.AddOrdreAsync(ordre);

            await PopupAction.DisplayPopup(new PopupPage());
        }
    }
}
