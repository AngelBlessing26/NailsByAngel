namespace NailssByAngel.DTOs
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
    }
}
