using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Queries.PoliclinicQueries
{
    public class GetByIdPoliclinicQueryRequest : IRequest<IDTO<PoliclinicListDTO?>>
    {
        public int PoliclinicId { get; set; }
    }
}
