using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Hotel
{
    public class UpdateHotelRequestDto
    {
        public string HotelName { get; set; } = string.Empty;
        public int Rooms { get; set; }
    }
}