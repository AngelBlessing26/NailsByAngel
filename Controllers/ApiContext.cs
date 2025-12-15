
namespace NailBookingAPI.Controllers
{
    internal class ApiContext
    {
        internal object Bookings;

        public object? Clients { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}