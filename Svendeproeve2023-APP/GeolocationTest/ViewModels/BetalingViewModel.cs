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
        [RelayCommand]
        public async void Betal()
        {
            await PopupAction.DisplayPopup(new PopupPage());
        }
    }
}
