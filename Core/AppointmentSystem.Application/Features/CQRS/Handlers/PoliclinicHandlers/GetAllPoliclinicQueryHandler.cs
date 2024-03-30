using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Queries.PoliclinicQueries;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PoliclinicHandlers
{
    public class GetAllPoliclinicQueryHandler : IRequestHandler<GetAllPoliclinicQueryRequest, IDTO<List<PoliclinicListDTO>?>>
    {
        private readonly IPoliclinicRepository _policlinicRepository;
        private readonly IMapper _mapper;

        public GetAllPoliclinicQueryHandler(IPoliclinicRepository policlinicRepository, IMapper mapper)
        {
            _policlinicRepository = policlinicRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<List<PoliclinicListDTO>?>> Handle(GetAllPoliclinicQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var datas = await _policlinicRepository.GetAllIncludedDoctorsAsync();
                if (datas != null)
                {
                    return new IDTO<List<PoliclinicListDTO>?>(200, _mapper.Map<List<PoliclinicListDTO>?>(datas), $"{datas.Count} poliklinik bulundu.");
                }
                else
                {
                    return new IDTO<List<PoliclinicListDTO>?>(404, null, "Poliklinik bulunamadı.");
                }
            }
            catch (Exception)
            {
                return new IDTO<List<PoliclinicListDTO>?>(500, null, "Bir hata oluştu.");
            }
        }
    }
}
