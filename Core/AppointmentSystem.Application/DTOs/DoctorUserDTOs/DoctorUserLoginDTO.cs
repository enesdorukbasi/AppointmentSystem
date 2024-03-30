using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.DTOs
{
    public class DoctorUserLoginDTO
    {
        public int AppUserId { get; set; }
        public string? IdentifierNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Degree { get; set; }
        public string? Card { get { return Degree + ". " + FullName; } }
        public string? Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
        public int PoliclinicId { get; set; }
        public PoliclinicListDTO? Policlinic { get; set; }
    }
}
