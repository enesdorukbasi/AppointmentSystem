using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PoliclinicHandlers
{
    public class UpdatePoliclinicCommandHandler : IRequestHandler<UpdatePoliclinicCommandRequest, IDTO<PoliclinicListDTO?>>
    {
        private readonly IRepository<Policlinic> _policlinicRepository;
        private readonly IMapper _mapper;

        public UpdatePoliclinicCommandHandler(IRepository<Policlinic> policlinicRepository, IMapper mapper)
        {
            _policlinicRepository = policlinicRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<PoliclinicListDTO?>> Handle(UpdatePoliclinicCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var unchangedData = await _policlinicRepository.GetById(request.PoliclinicId);
                if (unchangedData != null)
                {
                    unchangedData.Definition = request.Definition;
                    var updateResponse = await _policlinicRepository.UpdateAsync(unchangedData);
                    if (updateResponse != null)
                    {
                        return new IDTO<PoliclinicListDTO?>(200, _mapper.Map<PoliclinicListDTO>(updateResponse), "Bir hata oluştu.");
                    }                    
                }
                return new IDTO<PoliclinicListDTO?>(404, null, "Bir hata oluştu.");
            }
            catch (Exception)
            {
                return new IDTO<PoliclinicListDTO?>(500, null, "Bir hata oluştu.");
            }
        }
    }
}
