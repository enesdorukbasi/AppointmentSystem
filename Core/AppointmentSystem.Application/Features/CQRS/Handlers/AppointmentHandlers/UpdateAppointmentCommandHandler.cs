using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.AppointmentCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.AppointmentHandlers
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, IDTO<AppointmentListDTO?>>
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;
        public UpdateAppointmentCommandHandler(IRepository<Appointment> appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<AppointmentListDTO?>> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var unchangedData = await _appointmentRepository.GetById(request.PatientId);
                if (unchangedData != null)
                {
                    unchangedData.StartDate = request.StartDate;
                    unchangedData.EndDate = request.EndDate;
                    unchangedData.Description = request.Description;
                    unchangedData.IsCancelled = request.IsCancelled;
                    var changed = await _appointmentRepository.UpdateAsync(unchangedData);
                    if (changed != null)
                    {
                        return new IDTO<AppointmentListDTO?>(200, _mapper.Map<AppointmentListDTO>(unchangedData), "Güncelleme işlemi başarılı.");
                    }
                    else
                    {
                        return new IDTO<AppointmentListDTO?>(300, null, "Bir sorun oluştu.");
                    }
                }
                else
                {
                    return new IDTO<AppointmentListDTO?>(404, null, "Bu id'ye sahip bir randevu bulunamadı.");
                }
            }
            catch (Exception)
            {
                return new IDTO<AppointmentListDTO?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
