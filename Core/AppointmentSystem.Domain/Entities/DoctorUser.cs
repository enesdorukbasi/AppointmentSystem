namespace AppointmentSystem.Domain.Entities
{
    public class DoctorUser : AppUser
    {
        public string? Degree { get; set; }
        public string? Card { get { return Degree + ". " + FullName; } }
        public int PoliclinicId { get; set; }
        public Policlinic? Policlinic { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
