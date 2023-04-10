using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Models
{
    public class LocationPin
    {
        public string? Description { get; set; }
        public string? Address { get; set; }
        public Location? Location { get; set; }
        public ImageSource? ImageSource { get; set; }
    }
}
