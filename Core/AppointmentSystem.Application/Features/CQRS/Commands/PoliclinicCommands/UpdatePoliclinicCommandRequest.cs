using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands
{
    public class UpdatePoliclinicCommandRequest : IRequest<IDTO<PoliclinicListDTO?>>
    {
        public int PoliclinicId { get; set; }
        public string? Definition { get; set; }
    }
}
