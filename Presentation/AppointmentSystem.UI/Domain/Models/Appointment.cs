namespace AppointmentSystem.UI.Domain.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public bool IsClosedByDoctor { get; set; }
        public bool IsCancelled { get; set; }
        public PatientUser? PatientUser { get; set; }
        public DoctorUser? DoctorUser { get; set; }
    }
}
