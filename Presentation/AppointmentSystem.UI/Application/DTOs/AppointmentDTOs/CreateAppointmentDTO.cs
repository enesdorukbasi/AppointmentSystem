using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentSystem.UI.Application.DTOs
{
    public class CreateAppointmentDTO
    {
        public DateTime StartDate { get; set; }
        public string? Description { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public bool IsClosedByDoctor { get; set; }
        public bool IsCancelled { get; set; }
        public SelectList? DoctorUsers { get; set; }
    }
}
