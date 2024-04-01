using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries
{
    public class GetByIdAppointmentQueryRequest : IRequest<IDTO<AppointmentListDTO?>>
    {
        public int AppointmentId { get; set; }
    }
}
