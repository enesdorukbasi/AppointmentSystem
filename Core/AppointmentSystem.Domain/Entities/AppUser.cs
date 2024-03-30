namespace AppointmentSystem.Domain.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string? IdentifierNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
