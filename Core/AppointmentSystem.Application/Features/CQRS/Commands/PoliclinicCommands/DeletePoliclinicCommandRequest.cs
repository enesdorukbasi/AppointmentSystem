using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands
{
    public class DeletePoliclinicCommandRequest : IRequest<IDTO<object?>>
    {
        public int PoliclinicId { get; set; }
        public string? Definition { get; set; }
    }
}
