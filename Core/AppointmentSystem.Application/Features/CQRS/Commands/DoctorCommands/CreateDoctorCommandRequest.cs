using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands
{
    public class CreateDoctorCommandRequest : IRequest<IDTO<object?>>
    {
        public string? IdentifierNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Degree { get; set; }
        public int PoliclinicId { get; set; }
    }
}
