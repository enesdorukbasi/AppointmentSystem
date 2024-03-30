using AppointmentSystem.Application.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Commands.AppointmentCommands
{
    public class UpdateAppointmentCommandRequest : IRequest<IDTO<AppointmentListDTO?>>
    {
        public int AppointmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public bool IsClosedByDoctor { get; set; }
        public bool IsCancelled { get; set; }
    }
}
