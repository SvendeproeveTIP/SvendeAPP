using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Models
{
    public class Vehicles
    {
        public string VehicleName { get; set; }
        public decimal StartupPrice { get; set; }
        public bool IsRented { get; set; }
        public string Battery { get; set; }
        public double Lattitude { get; set; }
        public double Longtitude { get; set; }
        public bool UnderMaintenance { get; set; }
        public long TypeId { get; set; }
        public long? VehicleId { get; set; }
    }
}
