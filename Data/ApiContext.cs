using NailBookingAPI.;
using NailssByAngel.Models;
using System.Collections.Generic;
namespace NailssByAngel.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Service> Services { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
