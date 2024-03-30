using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.DoctorHandlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommandRequest, IDTO<object?>>
    {
        private readonly IRepository<DoctorUser> _doctorUserRepository;

        public CreateDoctorCommandHandler(IRepository<DoctorUser> doctorUserRepository)
        {
            _doctorUserRepository = doctorUserRepository;
        }

        public async Task<IDTO<object?>> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _doctorUserRepository.CreateAsync(new DoctorUser()
                {
                    IdentifierNumber = request.IdentifierNumber,
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password,
                    Degree = request.Degree,
                    PoliclinicId = request.PoliclinicId,
                });
                if(response != null)
                {
                    return new IDTO<object?>(201, response, "Doktor oluşturuldu.");
                }
                return new IDTO<object?>(300, null, "Bir sorun oluştu.");
            }
            catch (Exception)
            {
                return new IDTO<object?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
