using Microsoft.EntityFrameworkCore;
using NailssByAngel.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace NailsByAngel.Data
{
    public class ApiContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public System.Data.Entity.DbSet<Client> Clients { get; set; }
        public System.Data.Entity.DbSet<Booking> Bookings { get; set; }
        public System.Data.Entity.DbSet<Service> Services { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
