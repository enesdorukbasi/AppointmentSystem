using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Queries.PoliclinicQueries;
using AppointmentSystem.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PoliclinicHandlers
{
    public class GetByIdPoliclinicQueryHandler : IRequestHandler<GetByIdPoliclinicQueryRequest, IDTO<PoliclinicListDTO?>>
    {
        private readonly IPoliclinicRepository _policlinicRepository;
        private readonly IMapper _mapper;

        public GetByIdPoliclinicQueryHandler(IPoliclinicRepository policlinicRepository, IMapper mapper)
        {
            _policlinicRepository = policlinicRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<PoliclinicListDTO?>> Handle(GetByIdPoliclinicQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _policlinicRepository.GetByIdIncludedDoctorsAsync(request.PoliclinicId);
                return new IDTO<PoliclinicListDTO?>(
                    response != null ? 200 : 404, 
                    response != null ? _mapper.Map<PoliclinicListDTO>(response) : null, 
                    response != null ? "Data bulundu." : "Bir sorun oluştu."
                    );
            }
            catch (Exception)
            {
                return new IDTO<PoliclinicListDTO?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
