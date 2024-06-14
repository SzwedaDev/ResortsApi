using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Hotel
{
    public class HotelDto
    {
        public int ID { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public int Rooms { get; set; }
    }
}