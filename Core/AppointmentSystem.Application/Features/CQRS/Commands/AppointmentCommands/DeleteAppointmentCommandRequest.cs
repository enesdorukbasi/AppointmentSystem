using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.AppointmentCommands
{
    public class DeleteAppointmentCommandRequest : IRequest<IDTO<object?>>
    {
        public int AppointmentID { get; set; }
    }
}
