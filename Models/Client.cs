using NailssByAngel.Models;

namespace NailssByAngel.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Booking>? Bookings { get; set; } = new List<Booking>();
    }
}


