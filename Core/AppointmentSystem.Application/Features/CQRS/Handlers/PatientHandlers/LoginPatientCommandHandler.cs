using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.PatientCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Application.Tools;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.PatientHandlers
{
    public class LoginPatientCommandHandler : IRequestHandler<LoginPatientCommandRequest, IDTO<object?>>
    {
        private readonly IRepository<PatientUser> _patientUserRepository;
        private readonly IMapper _mapper;

        public LoginPatientCommandHandler(IRepository<PatientUser> patientUserRepository, IMapper mapper)
        {
            _patientUserRepository = patientUserRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<object?>> Handle(LoginPatientCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _patientUserRepository.GetByFilterAsync(x => x.IdentifierNumber == request.IdentifierNumber && x.Password == request.Password);
                if (response == null)
                {
                    return new IDTO<object?>(404, null, "Kimlik numarası veya şifre hatalı.");
                }
                else
                {
                    PatientUserListDTO dto = JwtTokenProcesses.GenerateToken(_mapper.Map<PatientUserListDTO>(response));
                    return new IDTO<object?>(200, dto, "Giriş işlemi başarılı.");
                }
            }
            catch (Exception)
            {
                return new IDTO<object?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
