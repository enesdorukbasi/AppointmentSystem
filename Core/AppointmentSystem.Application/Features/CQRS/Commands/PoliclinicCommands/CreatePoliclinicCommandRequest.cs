using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands
{
    public class CreatePoliclinicCommandRequest : IRequest<IDTO<object?>>
    {
        public string? Definition { get; set; }
    }
}
