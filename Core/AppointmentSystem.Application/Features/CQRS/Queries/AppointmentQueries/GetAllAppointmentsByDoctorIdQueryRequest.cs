using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries
{
    public class GetAllAppointmentsByDoctorIdQueryRequest : IRequest<IDTO<List<AppointmentListDTO>?>>
    {
        public int DoctorId { get; set; }
    }
}
