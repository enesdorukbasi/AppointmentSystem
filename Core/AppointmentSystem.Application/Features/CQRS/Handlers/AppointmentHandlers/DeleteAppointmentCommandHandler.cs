using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.AppointmentCommands;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.AppointmentHandlers
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, IDTO<object?>>
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public DeleteAppointmentCommandHandler(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IDTO<object?>> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appointmentRepository.GetById(request.AppointmentID);
                if (data != null)
                {
                    bool isDeleted = await _appointmentRepository.DeleteAsync(data);
                    return new IDTO<object?>(isDeleted ? 200 : 300, null, isDeleted ? "Silme işlemi başarılı." : "Bir sorun oluştu.");
                }
                else
                {
                    return new IDTO<object?>(404, null, "Bu id'ye sahip randevu bulunamadı.");
                }
            }
            catch (Exception)
            {
                return new IDTO<object?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
