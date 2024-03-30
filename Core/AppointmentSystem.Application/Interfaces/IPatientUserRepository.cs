using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IPatientUserRepository
    {
        Task<PatientUser?> LoginAsync(string identifierNumber, string password);
    }
}
