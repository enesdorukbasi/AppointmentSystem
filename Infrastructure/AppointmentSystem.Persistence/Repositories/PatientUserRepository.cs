using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Persistence.Repositories
{
    public class PatientUserRepository : Repository<PatientUser>, IPatientUserRepository
    {
        private readonly AppointmentSqlContext _context;

        public PatientUserRepository(AppointmentSqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PatientUser?> LoginAsync(string identifierNumber, string password)
        {
            var response = await _context.Set<PatientUser>().AsNoTracking().FirstAsync(x => x.IdentifierNumber == identifierNumber && x.Password == password);
            return response != null ? response : null;
        }
    }
}
