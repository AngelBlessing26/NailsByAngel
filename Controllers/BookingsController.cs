using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NailssByAngel.Data;
using NailssByAngel.DTOs;
using NailssByAngel.Models;
using NailssByAngel.Auth;


namespace NailssByAngel.Controllers
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase{}
  }
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly ApiContext _context;

        public BookingsController(ApiContext context)
        {
            _context = context;
        }

        // ✅ CREATE
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var clientExists = _context.Clients.Any(c => c.Id == dto.ClientId);
            var serviceExists = _context.Services.Any(s => s.Id == dto.ServiceId);

            if (!clientExists || !serviceExists)
            {
                return BadRequest("Invalid ClientId or ServiceId");
            }

            var booking = new Booking
            {
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId,
                Date = dto.Date
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok(booking);
        }

        // ✅ READ (GET ALL)
        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Service)
                .Select(b => new
                {
                    b.Id,
                    b.Date,
                    ClientName = b.Client.Name,
                    ServiceName = b.Service.Name,
                    b.Service.Price
                })
                .ToList();

            return Ok(bookings);
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return NoContent();
        }
    }


