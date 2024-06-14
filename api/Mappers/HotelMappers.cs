using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Hotel;
using api.models;

namespace api.Mappers
{
    public static class HotelMappers
    {
        public static HotelDto ToHotelDto(this Hotel hotelModel)
        {
            return new HotelDto
            {
                ID = hotelModel.ID,
                HotelName = hotelModel.HotelName,
                Rooms = hotelModel.Rooms
            };
        }

        public static Hotel ToHotelFromCreateDTO(this CreateHotelRequestDto hotelDto)
    {
        return new Hotel
        {
            HotelName = hotelDto.HotelName,
            Rooms = hotelDto.Rooms   
        };
    }
    }

}