using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.Dtos.Hotel;
using api.Mappers;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("Function")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public HotelController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("see_all")]
        public  IActionResult GetAll()
        {
            var hotels = _context.Hotel.ToList()
             .Select(s => s.ToHotelDto());

            return Ok(hotels);
        }

        [HttpGet("find_by/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var hotels = _context.Hotel.Find(id);
            if (hotels == null)
            {
                return NotFound();
            }
            return Ok(hotels.ToHotelDto());
        }
        
        [HttpGet("search_by/{name}")]
        public IActionResult SearchByName([FromRoute] string name)
        {
            Console.WriteLine("elo");
            var hotel = _context.Hotel.FirstOrDefault(x => x.HotelName == name);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel.ToHotelDto());
        }

        [HttpPost("add_hotel")]
        public IActionResult Create([FromBody] CreateHotelRequestDto hotelDto)
        {
            var hotelModel = hotelDto.ToHotelFromCreateDTO();
            _context.Hotel.Add(hotelModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new{id = hotelModel.ID}, hotelModel.ToHotelDto());
        }
        [HttpPut]
        [Route("change_hotel_by/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateHotelRequestDto updateDto)
        {
            var hotelModel = _context.Hotel.FirstOrDefault(x => x.ID == id);
            if (hotelModel == null)
            {
                return NotFound();
            }

            hotelModel.HotelName = updateDto.HotelName;
            hotelModel.Rooms = updateDto.Rooms;
            _context.SaveChanges();
            return Ok(hotelModel.ToHotelDto());
        }

        [HttpDelete]
        [Route("delete_hotel_by/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var hotelModel = _context.Hotel.FirstOrDefault(x => x.ID == id);
            if (hotelModel == null)
            {
                return NotFound();
            }
            _context.Hotel.Remove(hotelModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}