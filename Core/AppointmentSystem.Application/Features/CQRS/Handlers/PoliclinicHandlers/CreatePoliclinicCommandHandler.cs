using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PoliclinicHandlers
{
    public class CreatePoliclinicCommandHandler : IRequestHandler<CreatePoliclinicCommandRequest, IDTO<object?>>
    {
        private readonly IRepository<Policlinic> _policlinicRepository;

        public CreatePoliclinicCommandHandler(IRepository<Policlinic> policlinicRepository)
        {
            _policlinicRepository = policlinicRepository;
        }

        public async Task<IDTO<object?>> Handle(CreatePoliclinicCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _policlinicRepository.CreateAsync(new Policlinic()
                {
                    Definition = request.Definition,
                });
                if(response != null)
                {
                    return new IDTO<object?>(201, response, "Poliklinik oluşturuldu.");
                }
                return new IDTO<object?>(300, null, "Poliklinik oluşturulamadı.");
            }
            catch (Exception)
            {
                return new IDTO<object?>(500, null, "Poliklinik oluşturulamadı.");
            }
        }
    }
}
