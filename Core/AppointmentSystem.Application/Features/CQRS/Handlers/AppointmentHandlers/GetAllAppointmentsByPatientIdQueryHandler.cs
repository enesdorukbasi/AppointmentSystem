using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.AppointmentHandlers
{
    public class GetAllAppointmentsByPatientIdQueryHandler : IRequestHandler<GetAllAppointmentsByPatientIdQueryRequest, IDTO<List<AppointmentListDTO>?>>
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAllAppointmentsByPatientIdQueryHandler(IRepository<Appointment> appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<IDTO<List<AppointmentListDTO>?>> Handle(GetAllAppointmentsByPatientIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _appointmentRepository.GetAllByFilterAsync(x => x.PatientId == request.PatientId, [
                    x => x.DoctorUser!,
                    x => x.PatientUser!,
                ]); 
                if (response != null)
                {
                    return new IDTO<List<AppointmentListDTO>?>(200, _mapper.Map<List<AppointmentListDTO>>(response), $"{response!.Count} adet randevu bulundu.");
                }
                return new IDTO<List<AppointmentListDTO>?>(500, null, "Bir sorun oluştu.");
            }
            catch (Exception)
            {
                return new IDTO<List<AppointmentListDTO>?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
