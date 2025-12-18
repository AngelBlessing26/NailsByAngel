using Microsoft.EntityFrameworkCore;
using NailssByAngel.Models;
using NailssByAngel.Models;

namespace NailssByAngel.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
