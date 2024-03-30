using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PoliclinicHandlers
{
    public class DeletePoliclinicCommandHandler : IRequestHandler<DeletePoliclinicCommandRequest, IDTO<object?>>
    {
        private readonly IRepository<Policlinic> _policlinicRepository;

        public DeletePoliclinicCommandHandler(IRepository<Policlinic> policlinicRepository)
        {
            _policlinicRepository = policlinicRepository;
        }

        public async Task<IDTO<object?>> Handle(DeletePoliclinicCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await  _policlinicRepository.GetById(request.PoliclinicId);
                if (data == null)
                {
                    return new IDTO<object?>(404, null, "Bu id'ye sahip policlinic bulunamadı.");
                }
                else
                {
                    bool isDeleted = await _policlinicRepository.DeleteAsync(data);
                    return new IDTO<object?>(isDeleted ? 200 : 404, null, $"Silme işlemi {(isDeleted ? "başarılı" : "başarısız")}.");
                }
            }
            catch (Exception)
            {
                return new IDTO<object?>(500, null, "Bir hata oluştu.");
            }
        }
    }
}
