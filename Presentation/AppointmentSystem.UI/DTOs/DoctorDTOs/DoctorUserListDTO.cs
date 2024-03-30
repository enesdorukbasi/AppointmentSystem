namespace AppointmentSystem.UI.DTOs.DoctorDTOs
{
    public class DoctorUserListDTO
    {
        public int AppUserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public string? Degree { get; set; }
        public string? Card { get { return Degree + ". " + FullName; } }
    }
}
