using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllByPatientIdAsync();
        Task<List<Appointment>> GetAllByDoctorIdAsync();
    }
}
