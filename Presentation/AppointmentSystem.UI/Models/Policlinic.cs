namespace AppointmentSystem.UI.Models
{
    public class Policlinic
    {
        public int PoliclinicId { get; set; }
        public string? Definition { get; set; }
        public List<DoctorUser>? DoctorUsers { get; set; }
    }
}
