using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Reservation
    {
        public int ID { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public int? HotelID { get; set; }
        //Navigation properity
        public Hotel? Hotel { get; set; }
    }
}