namespace NailssByAngel.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; } = string.Empty;

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
