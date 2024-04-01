using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.DTOs.DoctorUserDTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.DoctorHandlers
{
    public class GetAllDoctorsByPoliclinicIdCommandHandler : IRequestHandler<GetAllDoctorsByPoliclinicIdCommandRequest, IDTO<List<DoctorUserListDTO>?>>
    {
        private readonly IRepository<DoctorUser> _doctorUserRepository;
        private readonly IMapper _mapper;

        public GetAllDoctorsByPoliclinicIdCommandHandler(IRepository<DoctorUser> doctorUserRepository, IMapper mapper)
        {
            _doctorUserRepository = doctorUserRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<List<DoctorUserListDTO>?>> Handle(GetAllDoctorsByPoliclinicIdCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<DoctorUser>? doctors = new List<DoctorUser>();
                if (request.PoliclinicId != 0)
                {
                    doctors = await _doctorUserRepository.GetAllByFilterAsync(x => x.PoliclinicId == request.PoliclinicId, [x => x.Policlinic!]);
                }
                else
                {
                    doctors = await _doctorUserRepository.GetAllAsync([x => x.Policlinic!]);
                }
                return new IDTO<List<DoctorUserListDTO>?>(200, _mapper.Map<List<DoctorUserListDTO>?>(doctors), $"{doctors.Count} adet doktor bulundu.");
            }
            catch (Exception)
            {
                return new IDTO<List<DoctorUserListDTO>?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
