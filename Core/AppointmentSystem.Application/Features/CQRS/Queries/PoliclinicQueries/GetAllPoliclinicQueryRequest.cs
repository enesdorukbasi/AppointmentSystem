using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Queries.PoliclinicQueries
{
    public class GetAllPoliclinicQueryRequest : IRequest<IDTO<List<PoliclinicListDTO>?>>
    {
    }
}
