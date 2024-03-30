using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.AppointmentCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.AppointmentHandlers
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, IDTO<AppointmentListDTO?>>
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(IRepository<Appointment> appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<AppointmentListDTO?>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _appointmentRepository.CreateAsync(new()
                {
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Description = request.Description,
                    PatientId = request.PatientId,
                    DoctorId = request.DoctorId,
                    IsClosedByDoctor = request.IsClosedByDoctor,
                    IsCancelled = request.IsCancelled,
                });
                if (response != null)
                {
                    return new IDTO<AppointmentListDTO?>(201, _mapper.Map<AppointmentListDTO>(response), "Ekleme işlemi başarılı.");
                }
                return new IDTO<AppointmentListDTO?>(300, null, "Bir sorun oluştu.");
            }
            catch (Exception)
            {
                return new IDTO<AppointmentListDTO?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
