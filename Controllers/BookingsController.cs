using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NailsByAngel.Data;
using NailssByAngel.DTOs;
using NailssByAngel.Models;

namespace NailBookingAPI.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly ApiContext _context;

        public BookingsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Service)
                .Select(b => new BookingResponseDto
                {
                    BookingId = b.Id,
                    ClientName = b.Client.Name,
                    ServiceName = b.Service.Name,
                    AppointmentDate = b.AppointmentDate
                });

            return Ok(bookings);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId,
                AppointmentDate = dto.AppointmentDate
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null) return NotFound();

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

