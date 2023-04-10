using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeolocationTest.Services;

namespace GeolocationTest.ViewModels
{
    public partial class TransportViewModel : BaseViewModel
    {
        TransportService transportService;
        IGeolocation geolocation;
        private bool _isCheckingLocation;

        public TransportViewModel(TransportService transportService, IGeolocation geolocation)
        {
            this.transportService = transportService;
            this.geolocation = geolocation;
        }

    }
}
