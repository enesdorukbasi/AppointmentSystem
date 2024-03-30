using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.PatientCommands
{
    public class LoginPatientCommandRequest : IRequest<IDTO<object?>>
    {
        public string IdentifierNumber { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
