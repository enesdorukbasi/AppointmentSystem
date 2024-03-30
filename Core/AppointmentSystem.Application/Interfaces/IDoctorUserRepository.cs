using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IDoctorUserRepository
    {
        Task<DoctorUser?> LoginAsync(string identifierNumber, string password);
    }
}
