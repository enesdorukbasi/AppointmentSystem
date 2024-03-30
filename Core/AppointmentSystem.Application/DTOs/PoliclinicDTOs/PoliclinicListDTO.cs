using AppointmentSystem.Application.DTOs.DoctorUserDTOs;
using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.DTOs
{
    public class PoliclinicListDTO
    {
        public int PoliclinicId { get; set; }
        public string? Definition { get; set; }
        public List<DoctorUserListDTO>? DoctorUsers { get; set; }
    }
}
