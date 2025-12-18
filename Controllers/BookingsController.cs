using Microsoft.AspNetCore.Mvc;
using NailssByAngel.Data;
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

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return Ok(booking);
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(_context.Bookings.ToList());
        }

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
}