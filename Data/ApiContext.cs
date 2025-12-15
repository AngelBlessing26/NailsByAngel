using Microsoft.EntityFrameworkCore;
using NailssByAngel.Models;
using System.Collections.Generic;

namespace NailsByAngel.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
