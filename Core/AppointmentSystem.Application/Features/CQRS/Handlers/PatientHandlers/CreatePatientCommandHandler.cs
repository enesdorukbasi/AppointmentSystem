using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.PatientCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PatientHandlers
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommandRequest, IDTO<object?>>
    {
        private readonly IRepository<PatientUser> _patientUserRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IRepository<PatientUser> patientUserRepository, IMapper mapper)
        {
            _patientUserRepository = patientUserRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<object?>> Handle(CreatePatientCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var responseData = await _patientUserRepository.CreateAsync(new PatientUser()
                {
                    IdentifierNumber = request.IdentifierNumber,
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password,
                    Address = request.Address,
                    City = request.City,
                });                
                return new IDTO<object?>(201, _mapper.Map<PatientUserListDTO>(responseData), "Ekleme başarılı.");
            }
            catch (Exception)
            {
                return new IDTO<object?>(404, null, "Ekleme işlemi sırasında hata ile karşılaşıldı.");
            }
        }
    }
}
