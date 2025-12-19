using Microsoft.EntityFrameworkCore;
using NailssByAngel.Models;


namespace NailssByAngel.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
