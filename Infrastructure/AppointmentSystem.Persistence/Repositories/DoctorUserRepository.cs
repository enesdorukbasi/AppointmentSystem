using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Persistence.Repositories
{
    public class DoctorUserRepository : Repository<DoctorUser>, IDoctorUserRepository
    {
        private readonly AppointmentSqlContext _context;

        public DoctorUserRepository(AppointmentSqlContext context) : base(context)
        {
            _context = context;
        }
        public async Task<DoctorUser?> LoginAsync(string identifierNumber, string password)
        {
            return await _context.Set<DoctorUser>().Include(x => x.Policlinic).AsNoTracking()
                .FirstAsync(x => x.IdentifierNumber == identifierNumber && x.Password == password);
        }
    }
}
