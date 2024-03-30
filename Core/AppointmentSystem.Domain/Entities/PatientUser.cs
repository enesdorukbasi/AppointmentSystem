namespace AppointmentSystem.Domain.Entities
{
    public class PatientUser : AppUser
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
