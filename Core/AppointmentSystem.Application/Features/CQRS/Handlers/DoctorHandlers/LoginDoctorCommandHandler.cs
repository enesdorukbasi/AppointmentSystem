using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Application.Tools;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.DoctorHandlers
{
    public class LoginDoctorCommandHandler : IRequestHandler<LoginDoctorCommandRequest, IDTO<object?>>
    {
        private readonly IDoctorUserRepository _doctorUserRepository;
        private readonly IMapper _mapper;
        public LoginDoctorCommandHandler(IDoctorUserRepository doctorUserRepository, IMapper mapper)
        {
            _doctorUserRepository = doctorUserRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<object?>> Handle(LoginDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _doctorUserRepository.LoginAsync(request.IdentifierNumber ?? "", request.Password ?? "");
                if(response != null)
                {
                    var dto = JwtTokenProcesses.GenerateToken(_mapper.Map<DoctorUserLoginDTO>(response));
                    return new IDTO<object?>(200, dto, "Giriş başarılı.");
                }
                return new IDTO<object?>(404, null, "Kimlik numarası veya şifre yanlış.");
            }
            catch (Exception)
            {
                return new IDTO<object?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
