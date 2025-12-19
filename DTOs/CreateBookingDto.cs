namespace NailssByAngel.DTOs
{
    public class CreateBookingDto
    {
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
    }
}
