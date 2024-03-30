using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IPoliclinicRepository
    {
        Task<List<Policlinic>?> GetAllIncludedDoctorsAsync();
        Task<Policlinic?> GetByIdIncludedDoctorsAsync(int id);
    }
}
