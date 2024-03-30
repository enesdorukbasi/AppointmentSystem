using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Persistence.Repositories
{
    public class PoliclinicRepository : Repository<Policlinic>, IPoliclinicRepository
    {
        private readonly AppointmentSqlContext _context;
        public PoliclinicRepository(AppointmentSqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Policlinic>?> GetAllIncludedDoctorsAsync()
        {
            return await _context.Set<Policlinic>().Include(x=>x.DoctorUsers).ToListAsync();
        }

        public async Task<Policlinic?> GetByIdIncludedDoctorsAsync(int id)
        {
            return await _context.Set<Policlinic>().Include(x => x.DoctorUsers).FirstAsync(x => x.PoliclinicId == id);
        }
    }
}
