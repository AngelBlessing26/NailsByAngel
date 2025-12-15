namespace NailssByAngel.DTOs
{
    public class CreateBookingDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }

        public int ServiceId { get; set; }
        public int ClientId { get; internal set; }
    }
}
