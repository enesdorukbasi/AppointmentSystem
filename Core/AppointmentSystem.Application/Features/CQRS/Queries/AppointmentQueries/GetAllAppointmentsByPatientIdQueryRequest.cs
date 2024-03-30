using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries
{
    public class GetAllAppointmentsByPatientIdQueryRequest : IRequest<IDTO<List<AppointmentListDTO>?>>
    {
        public int PatientId { get; set; }
    }
}
