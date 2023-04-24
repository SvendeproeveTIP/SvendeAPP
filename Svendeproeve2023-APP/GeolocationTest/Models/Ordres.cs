using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Models
{
    public class Ordres
    {
        public DateTime OrderDate { get; set; }
        public bool OrderEnded { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public long UserId { get; set; }
        public long VehicleId { get; set; }
        public long? OrdreId { get; set; }

    }
}
