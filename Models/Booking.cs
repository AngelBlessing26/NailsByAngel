namespace NailssByAngel.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }

    
}
