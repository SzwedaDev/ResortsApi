using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace api.models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public int Rooms { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}