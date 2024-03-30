using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.DTOs
{
    public class PatientUserListDTO
    {
        public int AppUserId { get; set; }
        public string? IdentifierNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}
