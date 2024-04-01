using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.DTOs.DoctorUserDTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands
{
    public class GetAllDoctorsByPoliclinicIdCommandRequest : IRequest<IDTO<List<DoctorUserListDTO>?>>
    {
        public int PoliclinicId { get; set; }
    }
}
